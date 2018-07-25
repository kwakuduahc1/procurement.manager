import { Component } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContractsHttpService } from '../../../Http/contracts-http';
import { IHttpHelper } from '../../../model/HttpHelper';
import { IContracts } from '../../../model/IContracts';
import { HttpErrorResponse } from '@angular/common/http';
import { SearchService } from '../../../services/SearchService';

@Component({
    selector: 'bs-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})
/** search component*/
export class SearchComponent implements IHttpHelper<IContracts[]>{

    processing: boolean = false;
    error: boolean = false;
    message: string = "";
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
        alert(this.message);
    }
    onSuccess(t: IContracts[]): void {
        this.results.set(t);
        this.processing = false;
        this.form.reset()
        this.router.navigate(["/search-contracts"]);
        this.router.dispose();
    }
    form: FormGroup;
    constructor(private router: Router, private http: ContractsHttpService, private results: SearchService) {
        this.form = new FormBuilder().group({
            search: new FormControl("", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(10)]))
        })
    }

    search(search: string) {
        this.http.search(search).subscribe(res => res.length > 0 ? this.onSuccess(res) : alert('Search returned 0 results'), (err: HttpErrorResponse) => this.onError(err));
    }
}