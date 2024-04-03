import { DecodeToken } from './../../models/auth/decode-token';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { User } from 'src/app/models/user/user';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router'
import { AlertifyService } from 'src/app/services/alertify/alertify.service'
import { UserService } from 'src/app/services/user/user.service'
import { PasswordChangeModel } from 'src/app/models/user/password-change-model'


@Component({
  selector: 'app-password-change',
  templateUrl: './password-change.component.html',
  styleUrls: ['./password-change.component.css'],
  providers: [UserService]
})
export class PasswordChangeComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private alertifyService: AlertifyService,
    private authService: AuthService,
    private router: Router) { }

  passwordChangeForm!: FormGroup
  passwordChangeModel!: PasswordChangeModel
  displayConfirmModal: string = 'none';
  decodeToken!: DecodeToken
  registrationNumber!: string

  ngOnInit(): void {
    this.createPasswordChangeForm()
    this.decodeToken = this.authService.decodeToken();
    this.registrationNumber=this.decodeToken.registrationNumber
    this.passwordChangeForm.controls["registrationNumber"].setValue(this.registrationNumber)
  }

  isLogin() {
    return this.authService.isLogIn()
  }

  createPasswordChangeForm() {
    this.passwordChangeForm = this.formBuilder.group({
      registrationNumber: ["", [Validators.required, Validators.min(1), Validators.max(99999), Validators.pattern("^[0-9]*$")]],
      password: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
    })
  }

passwordChange() {
    if (this.passwordChangeForm.valid) {
      this.passwordChangeModel = Object.assign({}, this.passwordChangeForm.value)
      if (this.passwordChangeModel) {
        this.userService.passwordChange(this.passwordChangeModel).subscribe(dataResult => {
          if (dataResult) {
            if (dataResult.success) {
              this.alertifyService.success(dataResult.message)
              this.router.navigateByUrl('dashboard')
            }
            else {
              this.alertifyService.error(dataResult.message)
            }
          }
        })
      }
    }
  }

  openConfirmModal() {
    this.displayConfirmModal = 'block';
    this.passwordChange()
  }

  closeConfirmModal()
  {
    this.displayConfirmModal="none"
  }

}
