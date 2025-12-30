import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { JobTitleService } from '../../services/job-title.service';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent implements OnInit {
  isEditMode = false;
  employeeId?: number;

  jobTitles: any[] = [];

  model = {
    firstName: '',
    lastName: '',
    email: '',
    salary: null as number | null,
    isActive: true,
    jobTitleId: null as number | null
  };

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private jobTitleService: JobTitleService
  ) {}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');

    if (idParam) {
      this.isEditMode = true;
      this.employeeId = Number(idParam);
    }

    this.jobTitleService.getJobTitles().subscribe({
      next: (titles) => {
        this.jobTitles = titles;

        if (this.isEditMode && this.employeeId) {
          this.loadEmployee(this.employeeId);
        }
      },
      error: () => {
        alert('Failed to load job titles');
      }
    });
  }

  loadEmployee(id: number): void {
    this.employeeService.getEmployeeById(id).subscribe({
      next: (employee) => {
        this.model.firstName = employee.firstName;
        this.model.lastName = employee.lastName;
        this.model.email = employee.email;
        this.model.salary = employee.salary;
        this.model.isActive = employee.isActive;
        this.model.jobTitleId = employee.jobTitleId;
      },
      error: () => {
        alert('Failed to load employee');
      }
    });
  }

  save(form: NgForm): void {
    if (form.invalid) {
      return;
    }

    if (this.isEditMode && this.employeeId) {
      this.employeeService
        .updateEmployee(this.employeeId, this.model)
        .subscribe(() => {
          alert('Employee updated successfully.');
        });
    } else {
      this.employeeService
        .createEmployee(this.model)
        .subscribe(() => {
          alert('Employee created successfully.');
          form.resetForm({ isActive: true });
        });
    }
  }
}
