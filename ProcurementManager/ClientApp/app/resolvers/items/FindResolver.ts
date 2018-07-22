import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { ContractsHttpService } from "../../Http/contracts-http";
import { SourcesHttpService } from "../../Http/sources-http";
import { ISources } from "../../model/ISources";

@Injectable()
export class FindContractResolver implements Resolve<Observable<ISources>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ISources> {
        return this.http.find(route.paramMap.get("id") as string);
    }

    constructor(private http: SourcesHttpService) { }
}