import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobTitleService {
  private readonly baseUrl = `${environment.apiBaseUrl}/jobtitles`;

  constructor(private http: HttpClient) {}

  getJobTitles(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
