﻿import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { IItems } from "../model/IItems";
import { IMonthlyReport } from "../model/IMonthlyReport";

@Injectable()
export class ReportsHttpService {

    constructor(private http: HttpClient) {

    }

    monthly(month:number, year:number): Observable<IMonthlyReport> {
        return this.http.get<IMonthlyReport>(`/Reports/Monthly?month=${month+1}&year=${year}`);
    }
}