import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AlertifyService } from '../alertify/alertify.service';
import { throwError } from 'rxjs';
import { AuditEnum } from 'src/app/enums/audit-enum.enum';
import { WebLogService } from '../web-log/web-log.service';
import { WebLog } from 'src/app/models/web-log/web-log';
import { UUID } from 'angular2-uuid'

@Injectable()
export class PipeService {

  constructor(private alertifyService: AlertifyService, private webLogService: WebLogService) { }

  handleError(error: HttpErrorResponse) {
    let errorMessage: string = ""
    if (error) {
      errorMessage = JSON.stringify(error)
      if (error.error) {
        errorMessage = JSON.stringify(error.error)
        if (error.error.message) {
          errorMessage = error.error.message
        }
      }
    }
    this.alertifyService.error(errorMessage)

    this.saveLog(AuditEnum.Error, errorMessage)

   return throwError(errorMessage)
  }


  saveLog(audit: AuditEnum, detail: string) {

    let webLog: WebLog = new WebLog()

    webLog.id = UUID.UUID()
    webLog.audit = audit
    webLog.detail = detail
    webLog.date = new Date()

    this.webLogService.add(webLog).subscribe(result => {
      if (result) {
        if (result.success) {
        }
      }
    })

  }




}
