/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditContractComponent } from './edit-contract.component';

let component: EditContractComponent;
let fixture: ComponentFixture<EditContractComponent>;

describe('edit-contract component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditContractComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditContractComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});