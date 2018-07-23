import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDefaultings } from '../../../model/IDefaultings';

@Component({
    selector: 'bs-defaulting',
    templateUrl: './defaulting.component.html',
    styleUrls: ['./defaulting.component.css']
})
/** defaulting component*/
export class DefaultingComponent {
    /** defaulting ctor */

    defaultings: IDefaultings[];
    constructor(route: ActivatedRoute) {
        this.defaultings = route.snapshot.data['defaults']
    }
}