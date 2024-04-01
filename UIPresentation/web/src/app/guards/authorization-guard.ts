import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Injectable } from "@angular/core";

import { AuthService } from "../services/auth/auth.service";

@Injectable()
export class AuthorizationGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private router: Router,
  ) { }

  isLogin: boolean = false

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let decodeToken = this.authService.decodeToken()
    let menuPaths = decodeToken.menuPaths
    let isAuthorization = false
    menuPaths.forEach(menuPath => {
      if (menuPath == route.url[0].path) {
        isAuthorization = true
      }
    })

    if (isAuthorization) {
      return true
    }

    this.router.navigateByUrl("login")
    return false
  }

}
