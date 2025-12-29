import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private readonly baseUrl = `${environment.apiBaseUrl}/employees`;

  constructor(private http: HttpClient) {}

  getEmployees(
    search: string,
    pageNumber: number,
    pageSize: number
  ): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize);

    if (search) {
      params = params.set('search', search);
    }

    return this.http.get<any>(this.baseUrl, { params });
  }

  getEmployeeById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  createEmployee(data: any): Observable<void> {
    return this.http.post<void>(this.baseUrl, data);
  }

  updateEmployee(id: number, data: any): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, data);
  }

  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
