import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { IMethods } from "../../model/IMethods";
import { MethodsHttpService } from "../../Http/methods-http";

@Injectable()
export class MethodsResolver implements Resolve<Observable<IMethods[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IMethods[]> {
        return this.http.list();
    }

    constructor(private http: MethodsHttpService) { }
}