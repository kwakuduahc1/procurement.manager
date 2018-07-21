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
import { EditContractComponent } from './components/Contracts/edit-contract/edit-contract.component';
import { ContractsListComponent } from './components/Contracts/contracts-list/contracts-list.component';
import { ContractsResolver } from './resolvers/contracts/ContractsResolver';
import { MethodsHttpService } from './Http/methods-http';
import { MethodsResolver } from './resolvers/methods/MethodsResolver';
import { FindContractResolver } from './resolvers/contracts/FindContractResolver';
import { ViewContractComponent } from './components/Contracts/view-contract/view-contract.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ContractsComponent,
        EditContractComponent,
        ContractsListComponent,
        ViewContractComponent
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
            { path: 'add-contracts', component: ContractsComponent, resolve: { methods: MethodsResolver } },
            { path: 'contracts', component: ContractsListComponent, resolve: { contracts: ContractsResolver } },
            { path: 'edit-contract/:id', component: EditContractComponent, resolve: { contract: FindContractResolver, methods: MethodsResolver } },
            { path: 'view-contract/:id', component: ViewContractComponent, resolve: { contract: FindContractResolver } },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ContractsHttpService,
        TimeLinesHttpService,
        ConParamsHttp,
        ContractsResolver,
        MethodsHttpService,
        MethodsResolver,
        FindContractResolver
    ]
})
export class AppModuleShared {
}
