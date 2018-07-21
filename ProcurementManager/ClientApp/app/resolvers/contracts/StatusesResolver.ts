import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { ContractsHttpService } from "../../Http/contracts-http";
import { IStatuses } from "../../model/IStatuses";

@Injectable()
export class StatusesResolver implements Resolve<Observable<IStatuses[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IStatuses[]> {
        return this.http.statuses();
    }

    constructor(private http: ContractsHttpService) { }
}