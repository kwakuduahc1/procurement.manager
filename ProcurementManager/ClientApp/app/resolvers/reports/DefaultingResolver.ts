import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { ContractsHttpService } from "../../Http/contracts-http";
import { IDefaultings } from "../../model/IDefaultings";
import { ReportsHttpService } from "../../Http/reports-http";

@Injectable()
export class DefaultingResolver implements Resolve<Observable<IDefaultings[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IDefaultings[]> {
        return this.http.defaulting();
    }

    constructor(private http: ReportsHttpService) { }
}