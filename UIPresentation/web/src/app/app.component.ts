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
  providers: [],
})
export class AppComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private menuService: MenuService,
    private alertifyService: AlertifyService,
    private router: Router
  ) {}

  title = 'ASAŞ FSEP 01';
  isLogin!: boolean;
  decodeToken!: DecodeToken;
  registrationNumber!: string;
  firstName!: string;
  lastName!: string;
  userMenuPaths!: string[];
  anyMenus!: Menu[];
  selectedMenuId!: number;
  userMenus!: Menu[];

  activateApp() {
    this.ngOnInit();
  }

  ngOnInit(): void {
    this.isLogin = this.authService.isLogIn();
    if (this.isLogin) {
      this.getCurrentUserInfo();
    }
  }

  logOut() {
    this.authService.logOut();
    if (!this.authService.getToken()) {
      this.router.navigateByUrl('login');
      this.isLogin = false;
    }
  }

  getCurrentUserInfo() {
    this.menuService.getAll().subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.anyMenus = dataResult.data;
            if (this.anyMenus) {
              if (this.anyMenus.length > 0) {
                this.decodeToken = this.authService.decodeToken();
                if (this.decodeToken) {
                  if (this.decodeToken.userNames) {
                    if (this.decodeToken.userNames.length > 0) {
                      this.firstName = this.decodeToken.userNames[0];
                      this.lastName = this.decodeToken.userNames[1];
                      if (this.decodeToken.registrationNumber) {
                        this.registrationNumber =this.decodeToken.registrationNumber;
                      }
                      if (this.decodeToken.menuPaths) {
                        if (this.decodeToken.menuPaths.length > 0) {
                          this.userMenuPaths = this.decodeToken.menuPaths;
                          this.userMenus=[]
                          this.anyMenus.forEach((anyMenu) => {
                            this.userMenuPaths.forEach((userMenuPath) => {
                              if (userMenuPath == anyMenu.path) {
                                this.userMenus.push(anyMenu);
                              }
                            });
                          });
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    });
  }

  setMenuId(menuId: number) {
    this.selectedMenuId = menuId;
  }
}
