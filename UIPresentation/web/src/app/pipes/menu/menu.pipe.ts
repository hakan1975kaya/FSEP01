import { AuthService } from './../../services/auth/auth.service';
import { DecodeToken } from './../../models/auth/decode-token';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'menuPipe'
})
export class MenuPipe implements PipeTransform {

  constructor(private authService: AuthService) { }

  transform(menuPath: string): string {
    let decodeToken: DecodeToken = this.authService.decodeToken()
    let menuPaths: string[] = decodeToken.menuPaths

    let isAuth: boolean = false

    menuPaths.forEach(eachpath => {
      if (eachpath == menuPath) {
        isAuth=true
      }
    })

    if(isAuth)
    {
      return "block"
    }
    return "none";
  }

}
