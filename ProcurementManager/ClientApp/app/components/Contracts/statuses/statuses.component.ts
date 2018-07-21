import { Component, Input, OnInit } from '@angular/core';
import { IStatuses } from '../../../model/IStatuses';

@Component({
    selector: 'bs-statuses',
    templateUrl: './statuses.component.html',
    styleUrls: ['./statuses.component.css']
})
/** statuses component*/
export class StatusesComponent implements OnInit {

    ngOnInit(): void {
        this.statuses.forEach(x => {
            this.polarAreaChartLabels.unshift(x.subject);
            this.polarAreaChartData.unshift(x.status);
        })
    }
    @Input('statuses') statuses: IStatuses[] = [];

    public polarAreaChartLabels: string[] = [];
    public polarAreaChartData: number[] = [];
    public polarAreaLegend: boolean = true;

    public polarAreaChartType: string = 'polarArea';
    constructor() {
    }
    // PolarArea

    // events
    public chartClicked(e: any): void {
       // console.log(e);
    }

    public chartHovered(e: any): void {
       // console.log(e);
    }
}