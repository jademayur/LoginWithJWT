import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Auth {

  private apiUrl = 'https://localhost:7009/api';
  
  constructor(private http:HttpClient) { }

  login(email: string, password: string) {
    return this.http
      .post<any>(`${this.apiUrl}/auth/login`, { email, password })
      .pipe(
        tap(res => sessionStorage.setItem('token', res.token))
      );
  }

   register(email: string, password: string, role: string) {
    return this.http.post(`${this.apiUrl}/users`, {
      email,
      password,
      role
    });
  }

    getToken(): string | null {
    return sessionStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  logout() {
    sessionStorage.clear();
  }
}
