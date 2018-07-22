import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { IItems } from "../../model/IItems";
import { ItemsHttpService } from "../../Http/items-http";

@Injectable()
export class ItemsResolver implements Resolve<Observable<IItems[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IItems[]> {
        return this.http.list();
    }

    constructor(private http: ItemsHttpService) { }
}