import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatatableservicesService } from './datatable/datatableservices.service';

const routes: Routes = [
  { path: 'get', component: DatatableservicesService },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
