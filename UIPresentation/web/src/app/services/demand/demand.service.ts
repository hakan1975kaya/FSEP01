import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, auditTime, catchError, tap } from 'rxjs';
import { ProcessStateL22PES } from 'src/app/models/ProcessStateL22PES/ProcessStateL22PES';
import { AuthService } from '../auth/auth.service';
import { environment } from 'src/environments/environment';
import { Result } from 'src/app/models/result/result';
import { PipeService } from '../pipe/pipe.service';
import { AuditEnum } from 'src/app/enums/audit-enum.enum';
import { DataResult } from 'src/app/models/result/data-result';
import { FilterModel } from 'src/app/models/general/filterModel';

@Injectable()
export class ProcessStateL22PESService {

  constructor(private authService: AuthService, private httpClient: HttpClient, private pipeService: PipeService) { }

  add(ProcessStateL22PES: ProcessStateL22PES): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<Result>(environment.path + "ProcessStateL22PESs/add", ProcessStateL22PES, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  update(ProcessStateL22PES: ProcessStateL22PES): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.put<Result>(environment.path + "ProcessStateL22PESs/update", ProcessStateL22PES, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  delete(id: string): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.delete<Result>(environment.path + "ProcessStateL22PESs/delete?id=" + id, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  getById(id: string): Observable<DataResult<ProcessStateL22PES>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<ProcessStateL22PES>>(environment.path + "ProcessStateL22PESs/getById?id=" + id, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  getAll(): Observable<DataResult<ProcessStateL22PES[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<ProcessStateL22PES[]>>(environment.path + "ProcessStateL22PESs/getAll", { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  search(filterModel: FilterModel): Observable<DataResult<ProcessStateL22PES[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<DataResult<ProcessStateL22PES[]>>(environment.path + "ProcessStateL22PESs/search", filterModel, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }



}
