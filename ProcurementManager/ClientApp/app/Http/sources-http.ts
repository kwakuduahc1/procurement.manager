import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { ISources } from "../model/ISources";

@Injectable()
export class SourcesHttpService implements IHttpMethods<ISources> {
    find(id: string | number): Observable<ISources> {
        return this.http.get<ISources>(`/Sources/Find?id=${id}`);
    }

    list(): Observable<ISources[]> {
        return this.http.get<ISources[]>('/Sources/List');
    }

    add(item: ISources): Observable<ISources> {
        return this.http.post<ISources>("/Sources/Create", item);
    }

    edit(item: ISources): Observable<ISources> {
        return this.http.put<ISources>("/Sources/Edit", item);
    }

    delete(item: ISources): Observable<void> {
        return this.http.post<void>("/Sources/Delete", item);
    }

    constructor(private http: HttpClient) {

    }
}