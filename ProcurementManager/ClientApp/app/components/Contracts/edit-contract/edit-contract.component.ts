import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { IContracts } from '../../../model/IContracts';
import { ContractsHttpService } from '../../../Http/contracts-http';
import { ActivatedRoute, Router } from '@angular/router';
import { IMethods } from '../../../model/IMethods';
import { IHttpHelper } from '../../../model/HttpHelper';
import { HttpErrorResponse } from '@angular/common/http';
import { IContractParameters } from '../../../model/IContractParameters';
import { DateTime } from 'luxon';
import { DatePipe } from '@angular/common';
@Component({
    selector: 'bs-edit-contract',
    templateUrl: './edit-contract.component.html',
    styleUrls: ['./edit-contract.component.css']
})
/** edit-contract component*/
export class EditContractComponent {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    params: FormGroup[] = [];
    form: FormGroup;
    methods: IMethods[];
    contract: IContracts;
    constructor(private router:Router, private http: ContractsHttpService, fb: FormBuilder, route: ActivatedRoute) {
        this.methods = route.snapshot.data['methods'];
        this.contract = route.snapshot.data['contract'];
        this.form = fb.group({
            subject: [this.contract.subject, Validators.compose([Validators.required, Validators.maxLength(150), Validators.minLength(20)])],
            methodsID: [this.contract.methodsID, Validators.compose([Validators.required, Validators.min(1)])],
            contractsID: [this.contract.contractsID],
            contractor: [this.contract.contractor, Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(200)])],
            amount: [this.contract.amount, Validators.compose([Validators.required, Validators.min(1)])],
            dateSigned: [this.contract.dateSigned, Validators.required],
            expectedDate: [this.contract.expectedDate],
            concurrency: [this.contract.concurrency]
        });
        this.contract.contractParameters.forEach(x => {
            this.params.unshift(new FormBuilder().group({
                contractParameter: [x.contractParameter, Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(150)])],
                percentage: [x.percentage, Validators.compose([Validators.required, Validators.min(1), Validators.max(100)])],
                amount: [x.amount, Validators.compose([Validators.required, Validators.min(1)])],
                contractsID: new FormControl({ value: x.contractsID, disabled: true }, Validators.required),
                contractParametersID: new FormControl({ value: x.contractParametersID, disabled: true }, Validators.required),
                concurrency: new FormControl({ value: x.concurrency, disabled: true }),
                expectedDate: [x.expectedDate, Validators.compose([Validators.required])]
            }))
        });
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
                this.message = "An unhandled error occurred. Contact support";
                break;

        }
    }


    addParam() {
        this.params.unshift(new FormBuilder().group({
            contractParameter: ["", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(150)])],
            percentage: ["", Validators.compose([Validators.required, Validators.min(1), Validators.max(100)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])],
            expectedDate: ["", Validators.compose([Validators.required])],
            contractsID: new FormControl({ value: this.contract.contractsID, disabled: true }, Validators.required),
            contractParametersID: new FormControl({ value: 0, disabled: true }, Validators.required),
            concurrency:[""]
        }));
    }

    removeParam(ix: number) {
        if (confirm("Removing this is irreversible. Do you wish to continue?"))
            this.params.splice(ix, 1);
    }

    onSuccess(t: IContracts) {
       this.router.navigate(['/contracts'])
    }

    add(con: IContracts, fgs: FormGroup[]) {
        this.processing = true;
        this.error = false;
        let params: IContractParameters[] = [];
        fgs.forEach(x => params.unshift({
            contractsID: this.contract.contractsID,
            contractParametersID: x.controls['contractParametersID'].value,
            amount: x.controls['amount'].value,
            contractParameter: x.controls['contractParameter'].value,
            expectedDate: x.controls['expectedDate'].value,
            isCompleted: false,
            percentage: x.controls['percentage'].value
        } as IContractParameters));
        con.contractParameters = params;
        this.http.edit(con).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
    }

    areFormsvalid(): boolean {
        return this.form.valid && this.params.every(t => t.valid);
    }

    checkSum() {
        return this.form.controls['amount'].value === this.params.reduce((pv, cv) => pv + cv.controls['amount'].value, 0);
    }

    checkPercentage(): boolean {
        return this.params.reduce((pv, cv) => pv + cv.controls['percentage'].value, 0) === 100
    }

    isSafe() {
        return this.checkSum()
    }
}