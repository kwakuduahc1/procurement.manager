/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ReportsHomeComponent } from './reports-home.component';

let component: ReportsHomeComponent;
let fixture: ComponentFixture<ReportsHomeComponent>;

describe('reports-home component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ReportsHomeComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ReportsHomeComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});