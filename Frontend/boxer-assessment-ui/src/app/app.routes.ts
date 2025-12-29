import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/home/home.component')
        .then(m => m.HomeComponent)
  },
  {
    path: 'employees',
    loadComponent: () =>
      import('./pages/employees/employee-list.component')
        .then(m => m.EmployeeListComponent)
  },
  {
    path: 'employees/new',
    loadComponent: () =>
      import('./pages/employees/employee-form.component')
        .then(m => m.EmployeeFormComponent)
  },
  {
    path: 'employees/:id/edit',
    loadComponent: () =>
      import('./pages/employees/employee-form.component')
        .then(m => m.EmployeeFormComponent)
  },
  {
    path: '**',
    redirectTo: ''
  }
];
