import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


import { ILogin } from '../../../shared/models/login.interface';
import { LoginService } from '../../../shared/services/api/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.sass'
})
export class LoginComponent {
  private loginService = inject(LoginService);
  private router = inject(Router);
  
  credentialError: boolean = false;
  errorMessage: string = '';
  form: FormGroup;
  private minLengthInput: number = 1;
  private maxLengthInput: number = 255;

  constructor() {
    this.form = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.minLength(this.minLengthInput),
        Validators.maxLength(this.maxLengthInput),
        Validators.email
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(this.minLengthInput),
        Validators.maxLength(this.maxLengthInput)
      ])
    });
  }

  onSubmit() {
    this.credentialError = false;
    if (this.form.valid) {
      const loginData: ILogin = this.form.value;
      this.loginService.signIn(loginData).subscribe({
        next: (response: string) => { 
          this.router.navigate(['menu']);
        },
        error: (error) => {
          this.credentialError = true;
          this.errorMessage = error;
          console.error(error);
        }
      });
    }
  }

  buildErrorMessageForm(controlName: string): string {
    const control = this.form.controls[controlName];
    if (control.touched && control.invalid) {
      if (control.hasError('required')) {
        return `${controlName.charAt(0).toUpperCase() + controlName.slice(1)} is required.`;
      }
      if (control.hasError('minlength')) {
        return `${controlName.charAt(0).toUpperCase() + controlName.slice(1)} must be at least ${this.minLengthInput} character long.`;
      }
      if (control.hasError('maxlength')) {
        return `${controlName.charAt(0).toUpperCase() + controlName.slice(1)} cannot be longer than ${this.maxLengthInput} characters.`;
      }
      if (control.hasError('email')) {
        return `Please enter a valid email address.`;
      }
    }
    return '';
  }
}
