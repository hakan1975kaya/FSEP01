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
import { Event } from 'src/app/models/event/event';

@Injectable()
export class EventService {

  constructor(private authService: AuthService, private httpClient: HttpClient, private pipeService: PipeService) { }

  add(event: Event): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<Result>(environment.path + "Events/add", event, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  update(event: Event): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.put<Result>(environment.path + "Events/update", event, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  delete(id: string): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.delete<Result>(environment.path + "Events/delete?id=" + id, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  getById(id: string): Observable<DataResult<Event>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<Event>>(environment.path + "Events/getById?id=" + id, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  getAll(): Observable<DataResult<Event[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<Event[]>>(environment.path + "Events/getAll", { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  search(filterModel: FilterModel): Observable<DataResult<Event[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<DataResult<Event[]>>(environment.path + "Events/search", filterModel, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }



}
