import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { IContracts } from "../model/IContracts";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { IStatuses } from "../model/IStatuses";

@Injectable()
export class ContractsHttpService implements IHttpMethods<IContracts> {
    find(id: string | number): Observable<IContracts> {
        return this.http.get<IContracts>(`/Contracts/Find?id=${id}`);
    }

    list(): Observable<IContracts[]> {
        return this.http.get<IContracts[]>('/Contracts/List');
    }

    statuses(): Observable<IStatuses[]> {
        return this.http.get<IStatuses[]>('/Contracts/Statuses');
    }

    add(item: IContracts): Observable<IContracts> {
        return this.http.post<IContracts>("/Contracts/Create", item);
    }

    search(id: string): Observable<IContracts[]> {
        return this.http.get<IContracts[]>(`/Contracts/Search?id=${id}`);
    }

    edit(item: IContracts): Observable<IContracts> {
        return this.http.put<IContracts>("/Contracts/Edit", item);
    }

    delete(item: IContracts): Observable<void> {
        return this.http.post<void>("/Contracts/Delete", item);
    }

    close(item: IContracts): Observable<void> {
        return this.http.put<void>("/Contracts/Close", item);
    }
    constructor(private http: HttpClient) {

    }
}