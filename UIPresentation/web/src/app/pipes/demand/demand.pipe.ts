import { AuthService } from './../../services/auth/auth.service';
import { DecodeToken } from './../../models/auth/decode-token';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'ProcessStateL22PESPipe'
})
export class ProcessStateL22PESPipe implements PipeTransform {

  constructor(private authService: AuthService) { }

  transform(ProcessStateL22PESName: string): string {
    let decodeToken: DecodeToken = this.authService.decodeToken()
    let ProcessStateL22PESNames: string[] = decodeToken.ProcessStateL22PESNames

    let isAuth: boolean = false

    ProcessStateL22PESNames.forEach(eachName => {
      if (eachName == ProcessStateL22PESName) {
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
