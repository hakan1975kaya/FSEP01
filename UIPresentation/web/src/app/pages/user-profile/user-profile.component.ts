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
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
  providers: [UserService]
})
export class UserProfileComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private alertifyService: AlertifyService,
    private authService: AuthService,
    private router: Router) { }

  passwordChangeForm!: FormGroup
  passwordChangeModel!: PasswordChangeModel
  decodeToken!: DecodeToken
  registrationNumber!: string
  firstName!: string
  lastName!: string
  displayConfirmModal: string = 'none';

  ngOnInit(): void {
    this.decodeToken = this.authService.decodeToken();
    this.registrationNumber=this.decodeToken.registrationNumber
    this.firstName=this.decodeToken.userNames[0]
    this.lastName=this.decodeToken.userNames[1].trimStart()
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

  changePassword() {
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
    this.changePassword()
  }

  closeConfirmModal()
  {
    this.displayConfirmModal="none"
  }

}
