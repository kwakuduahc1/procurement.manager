/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ContractsListComponent } from './contracts-list.component';

let component: ContractsListComponent;
let fixture: ComponentFixture<ContractsListComponent>;

describe('contracts-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ContractsListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ContractsListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});