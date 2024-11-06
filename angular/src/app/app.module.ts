import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupFormComponent } from './main/registration-form/signup/signup.component';
import { SubscriptionComponent } from './main/registration-form/subscription/subscription.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { MainComponent } from './main/main.component';
import { MainHeaderComponent } from './main/main-header/main-header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationFormComponent } from './main/registration-form/registration-form.component';
import { LoginComponent } from './main/login/login.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ValidatorInterceptor } from './shared/interceptors/validator.interceptor';
import { InternationalPhoneModule } from 'ng4-intl-phone';
import { LoginSuccessComponent } from './main/login-success/login-success.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupFormComponent,
    SubscriptionComponent,
    HeaderComponent,
    FooterComponent,
    MainComponent,
    MainHeaderComponent,
    RegistrationFormComponent,
    LoginComponent,
    LoginSuccessComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    InternationalPhoneModule 
  ],
  providers: [ 
    { provide: HTTP_INTERCEPTORS, useClass: ValidatorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
