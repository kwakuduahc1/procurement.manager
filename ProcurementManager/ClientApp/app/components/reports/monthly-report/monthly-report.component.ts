import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ReportsHttpService } from '../../../Http/reports-http';
import { IMonthlyReport } from '../../../model/IMonthlyReport';
import { IHttpHelper } from '../../../model/HttpHelper';
import { HttpErrorResponse } from '@angular/common/http';
import { getLocaleMonthNames, FormStyle, TranslationWidth } from '@angular/common';
import { PrintProviderService } from '../../../provider/print-provider.service';
import { DateTime } from 'luxon';

@Component({
    selector: 'bs-monthly-report',
    templateUrl: './monthly-report.component.html',
    styleUrls: ['./monthly-report.component.css']
})
/** monthly-report component*/
export class MonthlyReportComponent implements IHttpHelper<IMonthlyReport> {
    processing: boolean = false;;
    error: boolean = false;
    message: string = "";
    form: FormGroup;
    months: Array<{ id: number, month: string }> = [];
    years: number[] = [];
    report: IMonthlyReport = {
        completed: [], fresh: [], uncompleted: []
    };
    constructor(private http: ReportsHttpService, private printer: PrintProviderService) {
        this.form = new FormBuilder().group({
            month: [new Date().getMonth(), Validators.required],
            year: [new Date().getFullYear(), Validators.required]
        });
        this.initMonths();
    }

    initMonths() {
        var months = getLocaleMonthNames("en-US", FormStyle.Format, TranslationWidth.Wide);
        for (var i = 0; i < months.length; i++) {
            this.months.push({ id: i, month: months[i] });
        }
        let year = new Date().getFullYear();
        this.years = [year - 2, year - 1, year]
    }

    search(data: { month: number, year: number }) {
        this.processing = true;
        this.error = false;
        this.http.monthly(data.month, data.year).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
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

    onSuccess(t: IMonthlyReport): void {
        this.error = false;
        this.report = t;
    }

    print() {
        let mydate = DateTime.local();
        this.printer.print(`Procurement Report for ${mydate.monthLong} - ${mydate.year}`)
    }
}