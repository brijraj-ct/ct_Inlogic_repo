import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SharedService } from '../../services/shared.service';
import { UsersDto } from '../../Models/Users';
import { SubscriptionDto } from '../../Models/SubscriptionDto';
import { SignupService } from './signup.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { AmountModel } from '../../Models/Amount-Model';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupFormComponent implements OnInit {
  isChecked: boolean = false;
  isShowToast: boolean = false;
  userRegistrationForm = this.fb.group({});
  selectedSubscriptionDto: SubscriptionDto = {};
  amountsModel: AmountModel = {};
  @ViewChild('agreeCheckbox') agreeCheckbox: any;

  constructor(
    private fb: FormBuilder,
    private _signupService: SignupService,
    private _sharedService: SharedService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.userRegistrationForm = this.fb.group(
      {
        firstName: ['', [Validators.required]],
        lastName: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        phone: [
          '',
          [
            Validators.required,
            Validators.minLength(10),
            Validators.maxLength(15),
          ],
        ],
        gender: ['', [Validators.required]],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(8),
            this.passwordValidator,
          ],
        ],
        confirmPassword: ['', [Validators.required]],
      },
      { validators: this.passwordMatchValidator }
    );
    this._sharedService.data$.subscribe((data) => {
      this.selectedSubscriptionDto = data;
    });
    this._sharedService.amounts$.subscribe((data) => {
      this.amountsModel = data;
    });

    this._sharedService.buttonValue$.subscribe((data) => {
      if (data) {
        this.onSubmit();
      }
    });
  }

  passwordValidator(control: any) {
    const value = control.value;
    const hasUpperCase = /[A-Z]/.test(value);
    const hasLowerCase = /[a-z]/.test(value);
    const hasNumber = /[0-9]/.test(value);
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(value);
    const isValid = hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar;
    return isValid ? null : { invalidPassword: true };
  }

  passwordMatchValidator(form: FormGroup) {
    return form.get('password')?.value === form.get('confirmPassword')?.value
      ? null
      : form.get('confirmPassword')?.setErrors({ mismatch: true });
  }

  onSubmit() {
    if (this.userRegistrationForm.valid) {
      if (!this.agreeCheckbox?.nativeElement?.checked) {
        Swal.fire({
          title: 'Error',
          text: 'Please Agree to our Terms of use and Privacy Policy',
          icon: 'error',
        });
      } else {
        if (this.userRegistrationForm.valid) {
          let formValue = this.userRegistrationForm.value as any;
          let userDto: UsersDto = {
            firstName: formValue.firstName,
            lastName: formValue.lastName,
            email: formValue.email,
            phone: formValue.phone.toString(),
            gender: formValue.gender,
            password: formValue.password,
            confirmPassword: formValue.confirmPassword,
            subscriptionId: this.selectedSubscriptionDto.id ?? null,
            numberOfBranches:
              this.selectedSubscriptionDto.numberOfBranches ?? 1,
            paymentStatus: true,
            subscriptionAmount: this.amountsModel.subscriptionAmount,
            discountAmount: this.amountsModel.discountAmount,
            totalAmount: this.amountsModel.totalAmount,
          };
          this._signupService.registerUser(userDto).subscribe((res: any) => {
            if (res.success === true) {
              this._router.navigate(['/login']);
              Swal.fire({
                title: 'Success',
                text: 'Registered Successfully !!',
                icon: 'success',
              });
              this.userRegistrationForm.reset();
              this.hasMoreThenEightChar = false;
              this.hasUppercase = false;
              this.hasLowercase = false;
              this.hasSpecialChar = false;
              this.hasNumber = false;
            }
            this.hasMoreThenEightChar = true;
            this.hasUppercase = true;
            this.hasLowercase = true;
            this.hasSpecialChar = true;
            this.hasNumber = true;
          });
        }
      }
    } else {
      this.showErrors();
      this.userRegistrationForm.markAllAsTouched();
      return;
    }
  }

  showErrors() {
    let errorMessage = 'Please fix the following errors:\n';

    // Loop through each control and get the errors
    for (const controlName in this.userRegistrationForm.controls) {
      const control = this.userRegistrationForm.get(controlName);
      if (control?.errors) {
        // Add error messages for the control
        for (const errorKey in control.errors) {
          const error = control.errors[errorKey];

          // Default to controlName if no specific label is found
          const label =
            controlName ||
            controlName.charAt(0).toUpperCase() + controlName.slice(1);

          // Customize error messages for each type
          if (errorKey === 'required') {
            errorMessage += `<li>${label} is required.</li>`;
          } else if (errorKey === 'minlength') {
            errorMessage += `<li>${label} must be at least ${error.requiredLength} characters long.</li>`;
          } else if (errorKey === 'email') {
            errorMessage += `<li>Please enter a valid email address.</li>`;
          } else if (errorKey === 'pattern') {
            errorMessage += `<li>${label} has an invalid format.</li>`;
          } else if (errorKey === 'mismatch') {
            errorMessage += `<li>${label} and Confirm password doesn't match</li>`;
          } // Add other validation errors as needed
        }
      }
    }

    // Show the errors using SweetAlert
    Swal.fire({
      title: 'Error',
      html: errorMessage || 'An error occurred',
      icon: 'error',
    });
  }

  hasMoreThenEightChar: boolean = false;
  hasUppercase: boolean = false;
  hasLowercase: boolean = false;
  hasSpecialChar: boolean = false;
  hasNumber: boolean = false;

  checkPassword() {
    let password: string = (this.userRegistrationForm.value as any).password;
    this.hasMoreThenEightChar = password.length >= 8;
    this.hasUppercase = /[A-Z]/.test(password);
    this.hasLowercase = /[a-z]/.test(password);
    this.hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password);
    this.hasNumber = /[0-9]/.test(password);
  }

  countries = [
    { code: 'us', name: 'United States' },
    { code: 'gb', name: 'United Kingdom' },
    { code: 'ca', name: 'Canada' },
    { code: 'in', name: 'India' },
    // Add more countries as needed
  ];

  selectedCountryCode = 'us'; // Default country code
  phoneNumber = ''; // Two-way bound phone number field

  // Method to set the flag
  setFlag(countryCode: string) {
    this.selectedCountryCode = countryCode;
  }
}
