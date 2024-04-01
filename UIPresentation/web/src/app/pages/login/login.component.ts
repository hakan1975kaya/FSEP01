import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'

import { AuthService } from '../../services/auth/auth.service'
import { LoginModel } from 'src/app/models/auth/login-model'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: []
})
export class LoginComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
  ) { }

  loginForm!: FormGroup

  loginModel!: LoginModel

  ngOnInit(): void {
    this.createLoginForm()
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      registrationNumber: ["", Validators.required],
      password: ["", Validators.required]
    })
  }

  login() {
    if (this.loginForm.valid) {
      this.loginModel = Object.assign({}, this.loginForm.value)
      if (this.loginModel) {
        this.authService.login(this.loginModel)
      }
    }
  }
}
