import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BackgroundComponent } from './background/background.component';
import { AuthorizeGuard } from './chapter10_authen/api-authorization/authorize.guard';
import { LoginComponent } from './chapter10_authen/api-authorization/login/login.component';
import { FetchDataComponent } from './chapter10_authen/fetch-data/fetch-data.component';
import { HealthycheckComponent } from './chapter3/healthycheck/healthycheck.component';
import { CheckinternetComponent } from './checkinternet/checkinternet.component';
import { DatatableComponent } from './datatable/datatable.component';
const routes: Routes = [
  { path: '', component: BackgroundComponent },
  { path: 'get', component: DatatableComponent },
  { path: 'check', component: CheckinternetComponent },
  { path: 'hc', component: HealthycheckComponent },
  { path: 'fetch', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
  { path: 'login', component: LoginComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
