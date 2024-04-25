import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, auditTime, catchError, tap } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { environment } from 'src/environments/environment';
import { Result } from 'src/app/models/result/result';
import { PipeService } from '../pipe/pipe.service';
import { AuditEnum } from 'src/app/enums/audit-enum.enum';
import { DataResult } from 'src/app/models/result/data-result';
import { FilterModel } from 'src/app/models/general/filterModel';
import { ContactRoll } from 'src/app/models/contact-roll/contact-roll';

@Injectable()
export class ContactRollService {

  constructor(private authService: AuthService, private httpClient: HttpClient, private pipeService: PipeService) { }

  add(contactRoll: ContactRoll): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<Result>(environment.path + "ContactRolls/add", contactRoll, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  update(contactRoll: ContactRoll): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.put<Result>(environment.path + "ContactRolls/update", contactRoll, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  delete(id: string): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.delete<Result>(environment.path + "ContactRolls/delete?id=" + id, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  getById(id: string): Observable<DataResult<ContactRoll>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<ContactRoll>>(environment.path + "ContactRolls/getById?id=" + id, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  getAll(): Observable<DataResult<ContactRoll[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<ContactRoll[]>>(environment.path + "ContactRolls/getAll", { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  search(filterModel: FilterModel): Observable<DataResult<ContactRoll[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<DataResult<ContactRoll[]>>(environment.path + "ContactRolls/search", filterModel, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }



}
