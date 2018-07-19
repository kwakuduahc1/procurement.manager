﻿import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { IContracts } from "../model/IContracts";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ContractsHttpService implements IHttpMethods<IContracts> {
    find(id: string | number): Observable<IContracts> {
        return this.http.get<IContracts>(`/Contracts/Find?id=${id}`);
    }

    list(): Observable<IContracts[]> {
        return this.http.get<IContracts[]>('/Contracts/List');
    }

    add(item: IContracts): Observable<IContracts> {
        return this.http.post<IContracts>("/Contracts/Create", item);
    }

    edit(item: IContracts): Observable<IContracts> {
        return this.http.post<IContracts>("/Contracts/Edit", item);
    }

    delete(item: IContracts): Observable<void> {
        return this.http.post<void>("/Contracts/Delete", item);
    }

    constructor(private http: HttpClient) {

    }
}