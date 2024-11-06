import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login-success',
  templateUrl: './login-success.component.html',
  styleUrls: ['./login-success.component.css'],
})
export class LoginSuccessComponent implements OnInit {
  constructor(private _router: Router) {}
  returnUrl: string = '';
  ngOnInit(): void {
    debugger;
    this.returnUrl = this._router.url;
  }

  onLogout() {
    Swal.fire({
      title: 'Success',
      text: 'Logged out Successfully!!',
      icon: 'success',
    });
    this._router.navigate(['/login']);
  }
}
