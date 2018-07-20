import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ContractsComponent } from './components/Contracts/contracts/contracts.component';
import { ContractsHttpService } from './Http/contracts-http';
import { TimeLinesHttpService } from './Http/time-lines-http';
import { ConParamsHttp } from './Http/cont-params-http';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ContractsComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        ChartsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'contracts', component: ContractsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ContractsHttpService,
        TimeLinesHttpService,
        ConParamsHttp
    ]
})
export class AppModuleShared {
}
