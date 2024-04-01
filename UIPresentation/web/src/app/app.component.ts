import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from './services/auth/auth.service';
import { AlertifyService } from './services/alertify/alertify.service';
import { DecodeToken } from './models/auth/decode-token';
import { Menu } from './models/menu/menu';
import { MenuService } from './services/menu/menu.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: []
})

export class AppComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private menuService: MenuService,
    private alertifyService: AlertifyService,
    private router: Router) { }

  title = 'ASAŞ FSEP';
  isLogin!: boolean
  decodeToken!: DecodeToken
  registrationNumber!: string
  firstName!: string
  lastName!: string
  menuPaths!: string[]
  menus!: Menu[]
  selectedMenuId!: number

  activateApp() {
    this.ngOnInit()
  }

  ngOnInit(): void {
    this.isLogin = this.authService.isLogIn()
    if (this.isLogin) {
      this.getMenus()
      this.getCurrentUserInfo()
    }
  }

  logOut() {
    this.authService.logOut()
    if (!this.authService.getToken()) {
      this.router.navigateByUrl('login')
      this.isLogin = false
    }
  }

  getMenus() {
    this.menuService.getAll().subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.menus = dataResult.data
          }
        }
      }
    })
  }

  getCurrentUserInfo() {
    this.decodeToken = this.authService.decodeToken()
    if (this.decodeToken) {
      this.registrationNumber = this.decodeToken.registrationNumber
      if (this.decodeToken.userNames) {
        if (this.decodeToken.userNames.length > 0) {
          this.firstName = this.decodeToken.userNames[0]
          this.lastName = this.decodeToken.userNames[1]
        }
      }

      this.menuPaths = this.decodeToken.menuPaths
    }
  }


  setMenuId(menuId: number) {
    this.selectedMenuId = menuId
  }

  resetSelectedMenuId() {
    this.selectedMenuId = 0; // Set it to null or your default menu id
  }

}

