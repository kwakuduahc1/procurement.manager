import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IContracts } from '../../../model/IContracts';
import { ContractsHttpService } from '../../../Http/contracts-http';
import { ActivatedRoute } from '@angular/router';
import { IMethods } from '../../../model/IMethods';
import { IHttpHelper } from '../../../model/HttpHelper';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'bs-contracts',
    templateUrl: './contracts.component.html',
    styleUrls: ['./contracts.component.css']
})
/** contracts component*/
export class ContractsComponent implements IHttpHelper<IContracts> {
    processing: boolean =false;
    error: boolean = false;
    message: string="";
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
                this.message = "An unhandled error occurred. Contact support";
                break;

        }
    }
    onSuccess(t: IContracts) {
        this.contracts.unshift(t);
        this.error = false;
    }
    form: FormGroup;
    contracts: IContracts[];
    methods: IMethods[];
    constructor(private http: ContractsHttpService, fb: FormBuilder, route: ActivatedRoute) {
        this.contracts = route.snapshot.data['contracts'];
        this.methods = route.snapshot.data['methods'];
        this.form = fb.group({
            subject: ["", Validators.compose([Validators.required, Validators.maxLength(150), Validators.minLength(20)])],
            methodsID: ["", Validators.compose([Validators.required, Validators.min(1)])],
            contractor: ["", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(200)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])],
            dateSigned: ["", Validators.required],
            expectedDate: ["", Validators.required]
        })
    }

    add(con: IContracts) {
        this.processing = true;
        this.error = false;
        this.http.add(con).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
    }
}