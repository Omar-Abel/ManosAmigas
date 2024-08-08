import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { JsonOptions } from './httpOptions'; 

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7000/api/User/login';

  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(this.apiUrl, { email, password }, JsonOptions).pipe(
      map(response => {
        if (response && response.data && response.data.token) {
          localStorage.setItem('currentUser', JSON.stringify({
            id: response.data.id,
            firstName: response.data.firstName,
            lastName: response.data.lastName,
            email,
            accountType: response.data.accountType,
            token: response.data.token
          }));
          return response;
        } else {
          throw new Error('Login failed');
        }
      })
    );
  }
  

  logout(): void {
    localStorage.removeItem('currentUser');
  }

  public get loggedIn(): boolean {
    return localStorage.getItem('currentUser') !== null;
  }

}
