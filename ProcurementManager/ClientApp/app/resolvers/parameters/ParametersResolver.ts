﻿import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { IContractParameters } from "../../model/IContractParameters";
import { ConParamsHttp } from "../../Http/cont-params-http";

@Injectable()
export class ParametersResolver implements Resolve<Observable<IContractParameters[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IContractParameters[]> {
        return this.http.conList(route.paramMap.get("id") as string);
    }

    constructor(private http: ConParamsHttp) { }
}