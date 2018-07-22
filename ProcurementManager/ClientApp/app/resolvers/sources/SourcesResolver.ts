import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { ContractsHttpService } from "../../Http/contracts-http";
import { ISources } from "../../model/ISources";
import { SourcesHttpService } from "../../Http/sources-http";

@Injectable()
export class SourcesResolver implements Resolve<Observable<ISources[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ISources[]> {
        return this.http.list();
    }

    constructor(private http: SourcesHttpService) { }
}