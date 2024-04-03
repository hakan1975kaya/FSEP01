import { Component, OnInit } from '@angular/core';
import { DecodeToken } from 'src/app/models/auth/decode-token';
import { AuthService } from 'src/app/services/auth/auth.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
  providers: [UserService]
})
export class UserProfileComponent implements OnInit {
  decodeToken!: DecodeToken
  registrationNumber!: string
  firstName!: string
  lastName!: string

  constructor(    private authService: AuthService,){}

  ngOnInit(): void {
    this.decodeToken = this.authService.decodeToken();
    this.registrationNumber=this.decodeToken.registrationNumber
    this.firstName=this.decodeToken.userNames[0]
    this.lastName=this.decodeToken.userNames[1].trimStart()
  }

}
