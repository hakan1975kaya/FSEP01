import { Injectable } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { WebLog } from 'src/app/models/web-log/web-log';
import { Result } from 'src/app/models/result/result';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebLogService {

  constructor(private authService: AuthService, private httpClient: HttpClient) { }

  add(webLog: WebLog): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<Result>(environment.path + "WebLogs/add", webLog, { headers: httpHeaders })
  }
}
