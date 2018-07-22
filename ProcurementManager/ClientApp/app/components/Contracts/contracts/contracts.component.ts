import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IContracts } from '../../../model/IContracts';
import { ContractsHttpService } from '../../../Http/contracts-http';
import { ActivatedRoute } from '@angular/router';
import { IMethods } from '../../../model/IMethods';
import { IHttpHelper } from '../../../model/HttpHelper';
import { HttpErrorResponse } from '@angular/common/http';
import { IContractParameters } from '../../../model/IContractParameters';
import { ISources } from '../../../model/ISources';
import { IItems } from '../../../model/IItems';

@Component({
    selector: 'bs-contracts',
    templateUrl: './contracts.component.html',
    styleUrls: ['./contracts.component.css']
})
/** contracts component*/
export class ContractsComponent implements IHttpHelper<IContracts> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    params: FormGroup[] = [];
    form: FormGroup;
    methods: IMethods[];
    sources: ISources[];
    items: IItems[];
    constructor(private http: ContractsHttpService, fb: FormBuilder, route: ActivatedRoute) {
        this.methods = route.snapshot.data['methods'];
        this.sources = route.snapshot.data['sources'];
        this.items = route.snapshot.data['items'];
        this.form = fb.group({
            subject: ["", Validators.compose([Validators.required, Validators.maxLength(150), Validators.minLength(20)])],
            methodsID: ["", Validators.compose([Validators.required, Validators.min(1)])],
            contractor: ["", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(200)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])],
            dateSigned: ["", Validators.required],
            expectedDate: ["", Validators.required],
            itemsID: ["", Validators.compose([Validators.required, Validators.min(1)])],
            sourcesID: ["", Validators.compose([Validators.required, Validators.min(1)])]
        });
        this.addParam();
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

    addParam() {
        this.params.unshift(new FormBuilder().group({
            contractParameter: ["", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(150)])],
            percentage: ["", Validators.compose([Validators.required, Validators.min(1), Validators.max(100)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])],
            expectedDate: ["", Validators.compose([Validators.required])]
        }))
    }

    removeParam(ix: number) {
        if (confirm("Removing this is irreversible. Do you wish to continue?"))
            this.params.splice(ix, 1);
    }

    onSuccess(t: IContracts) {
        this.error = false;
        this.message = "Contract saved";
        this.form.reset();
        this.params.forEach(x => x.reset());
    }

    add(con: IContracts, fgs: FormGroup[]) {
        this.processing = true;
        this.error = false;
        let params: IContractParameters[] = [];
        fgs.forEach(x => params.unshift({
            amount: x.controls['amount'].value,
            contractParameter: x.controls['contractParameter'].value,
            expectedDate: x.controls['expectedDate'].value,
            isCompleted: false,
            percentage: x.controls['percentage'].value,
            contractsID: "my contract"
        } as IContractParameters));
        console.log(params);
        con.contractParameters = params;
        this.http.add(con).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
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