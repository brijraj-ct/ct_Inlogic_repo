import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UsersDto } from '../../Models/Users';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class SignupService {
  constructor(private http: HttpClient) {}

  registerUser(userDto: UsersDto) {
    return this.http.post(environment.apiEndPoint + 'auth/register', userDto);
  }
}
