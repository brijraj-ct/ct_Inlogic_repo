import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationFormComponent } from './main/registration-form/registration-form.component';
import { LoginComponent } from './main/login/login.component';
import { LoginSuccessComponent } from './main/login-success/login-success.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    // canActivate: [AuthGuard],
  },
  {
    path: 'login-success',
    component: LoginSuccessComponent,
  },
  {
    path: 'registration',
    component: RegistrationFormComponent,
  },
  {
    path: '',
    redirectTo: '/registration',
    pathMatch: 'full',
  },
  {
    path: '',
    component: RegistrationFormComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
