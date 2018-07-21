import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContractsHttpService } from '../../../Http/contracts-http';
import { IContracts } from '../../../model/IContracts';
import { IHttpHelper } from '../../../model/HttpHelper';
import { HttpErrorResponse } from '@angular/common/http';
import { tick } from '@angular/core/testing';

@Component({
    selector: 'bs-contracts-list',
    templateUrl: './contracts-list.component.html',
    styleUrls: ['./contracts-list.component.css']
})
/** contracts-list component*/
export class ContractsListComponent implements IHttpHelper<IContracts> {
    processing: boolean=false;
    error: boolean = false;
    message: string="";
    contracts: IContracts[];

    constructor(route:ActivatedRoute, private http:ContractsHttpService) {
        this.contracts = route.snapshot.data['contracts'];
    }

    delete(con: IContracts) {
        if (confirm('Deleting this contract is irreversible. Do you wish to continue?')) {
            this.http.delete(con).subscribe(() => this.onSuccess(con), (err: HttpErrorResponse) => this.onError(err));
        }
    }

    close(con: IContracts) {
        if (confirm('Do you wish to close this contract?')) {
            this.http.close(con).subscribe(() => this.onSuccess(con), (err: HttpErrorResponse) => this.onError(err));
        }
    }
    onError(err: HttpErrorResponse): void {
        if (err.error!.message) {
            this.message = err.error.message;
        }
        switch (err.status) {
            case 500:
                this.message = "A server error occurred. Contact support";
                break;
            case 400:
                this.message = err.error!.message;
                break;
            default:
                this.message = "An unexpected error occurred. Contact support";
                break;

        }
    }
    onSuccess(t: IContracts): void {
        let ix: number = this.contracts.findIndex(x => x.contractsID === t.contractsID);
        this.contracts.splice(ix, 1);
        this.message = "Operation was successfully";
    }
}