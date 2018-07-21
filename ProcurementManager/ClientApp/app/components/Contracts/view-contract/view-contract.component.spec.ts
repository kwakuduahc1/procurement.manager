/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ViewContractComponent } from './view-contract.component';

let component: ViewContractComponent;
let fixture: ComponentFixture<ViewContractComponent>;

describe('view-contract component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ViewContractComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ViewContractComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});