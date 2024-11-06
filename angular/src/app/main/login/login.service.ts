import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLogin } from '../Models/UserLogin';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}
  userLogin(userLogin: UserLogin) {
    return this.http.post(environment.apiEndPoint + 'auth/login', userLogin);
  }
}
