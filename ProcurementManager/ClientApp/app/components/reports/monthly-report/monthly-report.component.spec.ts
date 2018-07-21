/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MonthlyReportComponent } from './monthly-report.component';

let component: MonthlyReportComponent;
let fixture: ComponentFixture<MonthlyReportComponent>;

describe('monthly-report component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MonthlyReportComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MonthlyReportComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});