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
import { LubracationRoll } from 'src/app/models/lubracation-roll/lubracation-roll';

@Injectable()
export class LubracationRollService {

  constructor(private authService: AuthService, private httpClient: HttpClient, private pipeService: PipeService) { }

  add(lubracationRoll: LubracationRoll): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<Result>(environment.path + "LubracationRolls/add", lubracationRoll, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  update(lubracationRoll: LubracationRoll): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.put<Result>(environment.path + "LubracationRolls/update", lubracationRoll, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  delete(id: string): Observable<Result> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.delete<Result>(environment.path + "LubracationRolls/delete?id=" + id, { headers: httpHeaders }).pipe(tap(result => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(result))), catchError(error => this.pipeService.handleError(error)))
  }
  getById(id: string): Observable<DataResult<LubracationRoll>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<LubracationRoll>>(environment.path + "LubracationRolls/getById?id=" + id, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  getAll(): Observable<DataResult<LubracationRoll[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.get<DataResult<LubracationRoll[]>>(environment.path + "LubracationRolls/getAll", { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }
  search(filterModel: FilterModel): Observable<DataResult<LubracationRoll[]>> {
    const httpHeaders: HttpHeaders = new HttpHeaders().set("Authorization", "Bearer " + this.authService.getToken())
    return this.httpClient.post<DataResult<LubracationRoll[]>>(environment.path + "LubracationRolls/search", filterModel, { headers: httpHeaders }).pipe(tap(dataResult => this.pipeService.saveLog(AuditEnum.Info, JSON.stringify(dataResult))), catchError(error => this.pipeService.handleError(error)))
  }



}
