import { Injectable } from "@angular/core";
import { IContracts } from "../model/IContracts";

@Injectable()
export class SearchService {
    results: IContracts[] = [];
    constructor() {
    }

    set(res: IContracts[]) {
        this.results = res;
    }

    get(): IContracts[] {
        return this.results;
    }
}