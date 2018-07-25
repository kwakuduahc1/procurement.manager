import { Component } from '@angular/core';
import { IContracts } from '../../../model/IContracts';
import { SearchService } from '../../../services/SearchService';

@Component({
    selector: 'bs-search-results',
    templateUrl: './search-results.component.html',
    styleUrls: ['./search-results.component.css']
})
/** search-results component*/
export class SearchResultsComponent {
    results: IContracts[];
    constructor(search:SearchService) {
        this.results = search.get();
    }
}