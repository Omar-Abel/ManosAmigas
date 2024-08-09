import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  private apiUrl = 'https://localhost:7000/api/Activity/Activities';

  constructor(private http: HttpClient) { }

  addActivity(formData: FormData): Observable<any> {
    return this.http.post<any>('https://localhost:7000/api/Activity/addActivity', formData);
  }

  getActivities(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
