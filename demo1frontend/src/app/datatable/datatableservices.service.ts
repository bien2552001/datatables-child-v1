import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DatatableModel } from './datatablemodel.model';

@Injectable({
  providedIn: 'root'
})
export class DatatableservicesService {

  constructor(private http: HttpClient) { }

  getData(): Observable<Array<DatatableModel>> {
    return this.http.get<Array<DatatableModel>>('https://localhost:5001/api');
  }

}
