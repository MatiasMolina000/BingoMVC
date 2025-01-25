import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { ILogin } from '../../../shared/models/login.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.sass'
})
export class LoginComponent {
  form: FormGroup;
  private router = inject(Router);

  public credentialError: boolean = false;

  constructor() {
    this.form = new FormGroup({
      email: new FormControl('',[
        Validators.required
      ]),
      password: new FormControl('',[
        Validators.required
      ])
    })
  }

  onSubmit() {
    const loginData: ILogin = this.form.value;
    if (loginData.email == 'admin' && loginData.password == 'admin') {
      this.router.navigate(['menu']);
    } else {
      this.credentialError = true;
    }

  }
}
