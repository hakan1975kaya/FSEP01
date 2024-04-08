import { AuthService } from './../../services/auth/auth.service';
import { DecodeToken } from './../../models/auth/decode-token';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'demandPipe'
})
export class DemandPipe implements PipeTransform {

  constructor(private authService: AuthService) { }

  transform(demandName: string): string {
    let decodeToken: DecodeToken = this.authService.decodeToken()
    let demandNames: string[] = decodeToken.demandNames

    let isAuth: boolean = false

    demandNames.forEach(eachName => {
      if (eachName == demandName) {
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
