import { Component } from '@angular/core';
import { IContracts } from '../../../model/IContracts';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'bs-view-contract',
    templateUrl: './view-contract.component.html',
    styleUrls: ['./view-contract.component.css']
})
/** view-contract component*/
export class ViewContractComponent {
    contract: IContracts;
    form: FormGroup;
    constructor(router: ActivatedRoute) {
        this.contract = router.snapshot.data['contract'];
        this.form = new FormBuilder().group({
            contractParameter: ["", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(150)])],
            percentage: ["", Validators.compose([Validators.required, Validators.min(1), Validators.max(100)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])],
            expectedDate: ["", Validators.compose([Validators.required])]
        })
    }
}