import { Injectable } from "@angular/core";
import { IHttpMethods } from "./IHttpMethods";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { IItems } from "../model/IItems";

@Injectable()
export class ItemsHttpService implements IHttpMethods<IItems> {
    find(id: string | number): Observable<IItems> {
        return this.http.get<IItems>(`/Items/Find?id=${id}`);
    }

    list(): Observable<IItems[]> {
        return this.http.get<IItems[]>('/Items/List');
    }

    add(item: IItems): Observable<IItems> {
        return this.http.post<IItems>("/Items/Create", item);
    }

    edit(item: IItems): Observable<IItems> {
        return this.http.put<IItems>("/Items/Edit", item);
    }

    delete(item: IItems): Observable<void> {
        return this.http.post<void>("/Items/Delete", item);
    }

    constructor(private http: HttpClient) {

    }
}