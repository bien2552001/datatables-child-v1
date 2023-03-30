

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

declare var $: any;
@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.css']
})
export class DatatableComponent implements OnInit {

  dynamicdata: any;
  constructor(private http: HttpClient) {
    //get request from web api
    this.http.get('https://localhost:5001/api').subscribe(data => {
      this.dynamicdata = data;
      setTimeout(() => {
        $('#dataTables-example').DataTable({
          pagingType: 'full_numbers',
          pageLength: 5,
          processing: true,
          lengthMenu: [5, 10, 25]
        });
      }, 1);
    }, error => console.error(error));
  }

  ngOnInit() {

    //datepicker
    $('.dateadded').on('change', function (ret: any) {

      var v = ret.target.value  // getting search input value

      $('#dataTables-example').DataTable().columns(3).search(v).draw();
    });
  }
}

