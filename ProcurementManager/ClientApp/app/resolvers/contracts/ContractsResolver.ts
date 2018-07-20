import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { IContracts } from "../../model/IContracts";
import { Observable } from "rxjs/Observable";
import { ContractsHttpService } from "../../Http/contracts-http";

@Injectable()
export class ContractsResolver implements Resolve<Observable<IContracts[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IContracts[]> {
        return this.http.list();
    }

    constructor(private http: ContractsHttpService) { }
}