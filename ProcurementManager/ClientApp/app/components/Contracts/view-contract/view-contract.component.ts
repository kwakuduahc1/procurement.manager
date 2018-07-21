import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IContractParameters } from '../../../model/IContractParameters';
import { ConParamsHttp } from '../../../Http/cont-params-http';
import { IHttpHelper } from '../../../model/HttpHelper';
import { HttpErrorResponse } from '@angular/common/http';
import { IContracts } from '../../../model/IContracts';
import { PrintProviderService } from '../../../provider/print-provider.service';

@Component({
    selector: 'bs-view-contract',
    templateUrl: './view-contract.component.html',
    styleUrls: ['./view-contract.component.css']
})
/** view-contract component*/
export class ViewContractComponent implements IHttpHelper<IContractParameters> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    contract: IContracts;
    constructor(private http: ConParamsHttp, route: ActivatedRoute, private printer:PrintProviderService) {
        this.contract = route.snapshot.data['contract']
    }

    complete(par: IContractParameters) {
        this.processing = true;
        this.error = false;
        if (confirm('Do you wish to mark this parameter as completed?')) {
            this.http.edit(par).subscribe((res) => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        }
        this.processing = false;
    }

    print() {
        this.printer.print(this.contract.subject);
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
        this.error = true;
    }
    onSuccess(t: IContractParameters): void {
        let ix = this.contract.contractParameters.findIndex(x => x.contractParametersID == t.contractParametersID);
        this.contract.contractParameters[ix] = t;
    }
}