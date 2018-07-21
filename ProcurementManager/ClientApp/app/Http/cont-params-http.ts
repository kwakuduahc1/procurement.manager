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
        throw new Error("Method not implemented.");
        //return this.http.get<IContractParameters>(`/Parameters/Find?id=${id}`);
    }

    conList(id: string): Observable<IContractParameters[]> {
        throw new Error("Method not implemented.");//  return this.http.get<IContractParameters[]>(`/Parameters/List?id=${id}`);
    }

    add(item: IContractParameters): Observable<IContractParameters> {
        throw new Error("Method not implemented.");// return this.http.post<IContractParameters>("/Parameters/Create", item);
    }

    edit(item: IContractParameters): Observable<IContractParameters> {
        return this.http.put<IContractParameters>("/Parameters/Edit", item);
    }

    delete(item: IContractParameters): Observable<void> {
        throw new Error("Method not implemented.");//  return this.http.post<void>("/Parameters/Delete", item);
    }
    constructor(private http: HttpClient) {

    }
}