import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { IMethods } from "../model/IMethods";

@Injectable()
export class MethodsHttpService implements IHttpMethods<IMethods> {
    find(id: string | number): Observable<IMethods> {
        return this.http.get<IMethods>(`/Methods/Find?id=${id}`);
    }

    list(): Observable<IMethods[]> {
        return this.http.get<IMethods[]>('/Methods/List');
    }

    add(item: IMethods): Observable<IMethods> {
        return this.http.post<IMethods>("/Methods/Create", item);
    }

    edit(item: IMethods): Observable<IMethods> {
        return this.http.post<IMethods>("/Methods/Edit", item);
    }

    delete(item: IMethods): Observable<void> {
        return this.http.post<void>("/Methods/Delete", item);
    }

    constructor(private http: HttpClient) {

    }
}