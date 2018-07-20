import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IHttpMethods } from "./IHttpMethods";
import { IContractParameters } from "../model/IContractParameters";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ConParamsHttp implements IHttpMethods<IContractParameters>{
    list(): Observable<IContractParameters[]> {
        throw new Error("Method not implemented.");
    }

    find(id: string | number): Observable<IContractParameters> {
        return this.http.get<IContractParameters>(`/Contracts/Find?id=${id}`);
    }

    conList(id: string): Observable<IContractParameters[]> {
        return this.http.get<IContractParameters[]>(`/Contracts/List?id=${id}`);
    }

    add(item: IContractParameters): Observable<IContractParameters> {
        return this.http.post<IContractParameters>("/Contracts/Create", item);
    }

    edit(item: IContractParameters): Observable<IContractParameters> {
        return this.http.post<IContractParameters>("/Contracts/Edit", item);
    }

    delete(item: IContractParameters): Observable<void> {
        return this.http.post<void>("/Contracts/Delete", item);
    }
    constructor(private http: HttpClient) {

    }
}