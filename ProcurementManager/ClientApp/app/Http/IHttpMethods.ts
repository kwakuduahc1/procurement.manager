import { Observable } from "rxjs/Observable";

export interface IHttpMethods<T> {
    find(id: string | number): Observable<T> | null;
    list(): Observable<T[]>;
    add(item: T): Observable<T>;
    edit(item: T): Observable<T>;
    delete(item: T): Observable<void>;
}