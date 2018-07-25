/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SearchResultsComponent } from './search-results.component';

let component: SearchResultsComponent;
let fixture: ComponentFixture<SearchResultsComponent>;

describe('search-results component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SearchResultsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SearchResultsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});