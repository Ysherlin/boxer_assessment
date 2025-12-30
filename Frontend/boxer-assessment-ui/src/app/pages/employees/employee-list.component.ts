import { Component, inject, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

interface PagedResult<T> {
  items: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
}

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {
  private employeeService = inject(EmployeeService);
  private router = inject(Router);

  search = signal<string>('');
  loading = signal<boolean>(false);

  pageNumber = signal<number>(1);
  pageSize = 10;

  private resultsState = signal<PagedResult<any>>({
    items: [],
    totalCount: 0,
    pageNumber: 1,
    pageSize: 10
  });

  employees = computed(() => this.resultsState().items);
  totalCount = computed(() => this.resultsState().totalCount);

  totalPages = computed(() =>
    Math.ceil(this.totalCount() / this.pageSize)
  );

  private searchTimeout: any;

  ngOnInit(): void {
    this.loadPage(1);
  }

  onSearchChange(): void {
    clearTimeout(this.searchTimeout);
    this.searchTimeout = setTimeout(() => {
      this.loadPage(1);
    }, 300);
  }

  loadPage(page: number): void {
    this.pageNumber.set(page);
    this.loading.set(true);

    this.employeeService
      .getEmployees(
        this.search(),
        page,
        this.pageSize
      )
      .subscribe({
        next: (res) => {
          this.resultsState.set({
            items: res.items,
            totalCount: res.totalCount,
            pageNumber: page,
            pageSize: this.pageSize
          });
          this.loading.set(false);
        },
        error: (err) => {
          alert(err?.error?.message ?? 'Failed to load employees');
          this.loading.set(false);
        }
      });
  }

  nextPage(): void {
    if (this.pageNumber() < this.totalPages()) {
      this.loadPage(this.pageNumber() + 1);
    }
  }

  previousPage(): void {
    if (this.pageNumber() > 1) {
      this.loadPage(this.pageNumber() - 1);
    }
  }

  editEmployee(id: number): void {
    this.router.navigate(['/employees', id, 'edit']);
  }

  deleteEmployee(id: number): void {
    if (!confirm('Are you sure you want to delete this employee?')) {
      return;
    }

    this.employeeService.deleteEmployee(id).subscribe({
      next: () => {
        alert('Employee deleted successfully.');
        this.loadPage(this.pageNumber());
      },
      error: (err) => {
        alert(err?.error?.message ?? 'Delete failed');
      }
    });
  }

  createEmployee(): void {
    this.router.navigate(['/employees/new']);
  }
}
