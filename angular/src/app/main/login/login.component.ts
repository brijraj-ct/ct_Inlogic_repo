import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from '../Models/UserLogin';
import { LoginService } from './login.service';
import { SharedService } from '../services/shared.service';
import { Router, RouterLink } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = this.fb.group({});
  isLoginSuccess: boolean = false;
  isLogin = false;
  constructor(
    private fb: FormBuilder,
    private _loginService: LoginService,
    private _sharedService: SharedService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  onSubmit() {
    let formValue = this.loginForm.value as any;
    let userDetail: UserLogin = {
      email: formValue.email,
      password: formValue.password,
    };
    this._loginService.userLogin(userDetail).subscribe((res: any) => {
      this.loginForm.reset();
      if (res.success === true) {
        this.isLoginSuccess = true;
        Swal.fire({
          title: 'Success',
          text: 'Logged In Successfully!!',
          icon: 'success',
        });
        this._router.navigate(['/login-success']);
      } else {
        Swal.fire({
          title: 'Error',
          text: 'Invalid Username or Password.',
          icon: 'error',
        });
      }
    });
  }

  onSignup() {
    this._sharedService.setButtonValue(false);
    this._router.navigate(['/registration']);
  }
}
