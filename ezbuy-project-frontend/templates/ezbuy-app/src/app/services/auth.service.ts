import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7294/api/User/';

  constructor(private http: HttpClient) {}

  login(obj: any): Observable<any> {
    return this.http.post(this.apiUrl + 'login', obj);
  }

  register(obj: any): Observable<any> {
    return this.http.post(this.apiUrl + 'register', obj);
  }
}
