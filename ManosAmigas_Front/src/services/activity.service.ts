import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  private apiUrl = 'https://localhost:7000/api/Activity/Activities';
  private apiUrlDelete = 'https://localhost:7000/api/Activity'

  constructor(private http: HttpClient) { }

  addActivity(formData: FormData): Observable<any> {
    return this.http.post<any>('https://localhost:7000/api/Activity/addActivity', formData);
  }

  deleteActivity(id: number): Observable<any> {
    const url = `${this.apiUrlDelete}/${id}`;
    return this.http.delete(url);
  }

  getActivities(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
