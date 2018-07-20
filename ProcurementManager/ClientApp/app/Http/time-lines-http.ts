import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { ITimelines } from "../model/ITimelines";

@Injectable()
export class TimeLinesHttpService implements IHttpMethods<ITimelines> {

    find(id: string | number): Observable<ITimelines> {
        return this.http.get<ITimelines>(`/Contracts/Find?id=${id}`);
    }

    list(): Observable<ITimelines[]> {
        return this.http.get<ITimelines[]>('/Contracts/List');
    }

    add(item: ITimelines): Observable<ITimelines> {
        return this.http.post<ITimelines>("/Contracts/Create", item);
    }

    edit(item: ITimelines): Observable<ITimelines> {
        return this.http.post<ITimelines>("/Contracts/Edit", item);
    }

    delete(item: ITimelines): Observable<void> {
        return this.http.post<void>("/Contracts/Delete", item);
    }

    constructor(private http: HttpClient) {

    }
}