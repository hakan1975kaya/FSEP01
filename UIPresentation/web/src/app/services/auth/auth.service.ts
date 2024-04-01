import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Router } from '@angular/router';

import { AlertifyService } from '../alertify/alertify.service';
import { JwtHelperService } from '@auth0/angular-jwt'

import { environment } from '../../../environments/environment';

import { DataResult } from '../../models/result/data-result';
import { LoginModel } from 'src/app/models/auth/login-model';
import { AccessToken } from 'src/app/models/auth/access-token';
import { RegisterModel } from 'src/app/models/auth/register-model';
import { DecodeToken } from 'src/app/models/auth/decode-token';
import { ClaimXmlSoap } from 'src/app/constants/claim-xml-soap';
import { ClaimMicrosoft } from 'src/app/constants/claim-microsoft';

@Injectable()
export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private alertifyService: AlertifyService,
    private router: Router,
  ) { }

  @Output() activateApp: EventEmitter<void> = new EventEmitter<void>();
  jwtHelperService: JwtHelperService = new JwtHelperService()

  login(loginModel: LoginModel) {
    this.httpClient.post<DataResult<AccessToken>>(environment.path + "Auths/login", loginModel)
      .subscribe(dataResult => {
        if (dataResult) {
          if (dataResult.success) {
            if (dataResult.data) {
              if (dataResult.data.token) {
                localStorage.setItem("token", dataResult.data.token)
                this.router.navigateByUrl('dashboard')
              }
            }
          }
          else {
            this.alertifyService.error(dataResult.message)
          }
        }
      })
  }

  register(registerModel: RegisterModel) {
    this.httpClient.post<DataResult<AccessToken>>(environment.path + "Auths/register", registerModel)
      .subscribe(dataResult => {
        if (dataResult) {
          if (dataResult.success) {
            if (dataResult.data) {
              if (dataResult.data.token) {

                localStorage.setItem("token", dataResult.data.token)
                this.router.navigateByUrl('dashboard')
              }
            }
          }
          else {
            this.alertifyService.error(dataResult.message)
          }
        }
      })
  }

  isLogIn() {
    return !this.jwtHelperService.isTokenExpired(this.getToken())
  }

  getToken() {
    return localStorage.getItem("token")
  }

  decodeToken(): DecodeToken {
    let decodeToken: DecodeToken = new DecodeToken()
    let token = this.getToken()?.toString()
    if (token) {
      let tokenAny = this.jwtHelperService.decodeToken(token == undefined ? "" : token.toString())
      if (tokenAny) {
        let demandNames: string[] = tokenAny[ClaimMicrosoft.path + "role"]
        let userNames: string[] = tokenAny[ClaimXmlSoap.path + "name"]
        let menuPaths: string[] = tokenAny[ClaimXmlSoap.path + "uri"]

        decodeToken.aud = tokenAny["aud"]
        decodeToken.exp = tokenAny["exp"]
        decodeToken.iss = tokenAny["iss"]
        decodeToken.userNames = []
        decodeToken.nameidentifier = tokenAny[ClaimXmlSoap.path + "nameidentifier"]
        decodeToken.nbf = tokenAny["nbf"]
        decodeToken.registrationNumber = tokenAny[ClaimMicrosoft.path + "serialnumber"]
        decodeToken.demandNames = []
        decodeToken.menuPaths = []

        if (userNames) {
          userNames.forEach(userName => {
            decodeToken.userNames.push(userName)
          })

        }

        if (demandNames) {
          demandNames.forEach(demandName => {
            decodeToken.demandNames.push(demandName)
          })

        }

        if (menuPaths) {
          menuPaths.forEach(menuPath => {
            decodeToken.menuPaths.push(menuPath)
          })
        }

      }

    }


    return decodeToken
  }

  logOut() {
    localStorage.removeItem("token")
  }


}
