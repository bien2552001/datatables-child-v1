import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DatatableComponent } from './datatable/datatable.component';
import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from 'angular-datatables';
import { OnlineStatusModule } from 'ngx-online-status';
import { CheckinternetComponent } from './checkinternet/checkinternet.component';
import { HealthycheckComponent } from './chapter3/healthycheck/healthycheck.component';
import { BackgroundComponent } from './background/background.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ApiAuthorizationComponent } from './chapter10_authen/api-authorization/api-authorization.component';
import { LoginComponent } from './chapter10_authen/api-authorization/login/login.component';
import { LogoutComponent } from './chapter10_authen/api-authorization/logout/logout.component';
import { LoginMenuComponent } from './chapter10_authen/api-authorization/login-menu/login-menu.component';
import { FetchDataComponent } from './chapter10_authen/fetch-data/fetch-data.component';

@NgModule({
  declarations: [
    AppComponent,
    DatatableComponent,
    CheckinternetComponent,
    HealthycheckComponent,
    BackgroundComponent,
    ApiAuthorizationComponent,
    LoginComponent,
    LoginMenuComponent,
    LogoutComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DataTablesModule,
    OnlineStatusModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
