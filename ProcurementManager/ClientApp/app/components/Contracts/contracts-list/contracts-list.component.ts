import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContractsHttpService } from '../../../Http/contracts-http';
import { IContracts } from '../../../model/IContracts';

@Component({
    selector: 'bs-contracts-list',
    templateUrl: './contracts-list.component.html',
    styleUrls: ['./contracts-list.component.css']
})
/** contracts-list component*/
export class ContractsListComponent {
    contracts: IContracts[];

    constructor(route:ActivatedRoute, private http:ContractsHttpService) {
        this.contracts = route.snapshot.data['contracts'];
    }
}