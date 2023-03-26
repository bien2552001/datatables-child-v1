


//import { Component, OnInit } from '@angular/core';
//import { DatatableModel } from './datatablemodel.model';
//import { DatatableservicesService } from './datatableservices.service';
//declare var $: any;

//@Component({
//  selector: 'app-datatable',
//  templateUrl: './datatable.component.html',
//  styleUrls: ['./datatable.component.css']
//})
//export class DatatableComponent implements OnInit {
//  dynamicdata: DatatableModel[] = [];

//  constructor(private dataService: DatatableservicesService) { }

//  ngOnInit(): void {
//    this.getData();
//  }

//  getData(): void {
//    this.dataService.getData().subscribe(
//      data => {
//        // Filter the data by search date
//        const searchDate = $('#search-date').val();
//        this.dynamicdata = data.filter(item => {
//          return searchDate ? item.date === searchDate : true;
//        });

//        // Draw the table only if there is at least one row that matches the search date
//        if (this.dynamicdata.length > 0) {
//          setTimeout(() => {
//            $('#dataTables-example').DataTable({
//              pagingType: 'full_numbers',
//              pageLength: 5,
//              processing: true,
//              lengthMenu: [5, 10, 25]
//            });
//          }, 1);
//        }
//      },
//      error => console.error(error)
//    );
//  }

//  searchDate(): void {
//    const searchDate = $('#search-date').val();
//    $('#dataTables-example').DataTable().columns(3).search(searchDate).draw();
//  }
//}



//import { Component, OnInit } from '@angular/core';
//import { DatatableModel } from './datatablemodel.model';
//import { DatatableservicesService } from './datatableservices.service';
//declare var $: any;
//@Component({
//  selector: 'app-datatable',
//  templateUrl: './datatable.component.html',
//  styleUrls: ['./datatable.component.css']
//})
//export class DatatableComponent implements OnInit {
//  dynamicdata: DatatableModel[] = [];
//  dateadded: string = '';

//  constructor(private dataService: DatatableservicesService) { }

//  ngOnInit(): void {
//    this.getData()
//  }
//  getData(): void {
//    this.dataService.getData().subscribe(
//      data => {
//        this.dynamicdata = data;
//        setTimeout(() => {
//          $('#dataTables-example').DataTable({
//            pagingType: 'full_numbers',
//            pageLength: 5,
//            processing: true,
//            lengthMenu: [5, 10, 25]
//          });
//        }, 1);
//      },
//      error => console.error(error)
//    );
//  }

//  searchDate(ret: any): void {
//    const v = this.dateadded; // getting search input value
//    const table = $('#dataTables-example').DataTable();
//    if (v !== '') {
//      table.column(3).search(v).draw();
//      table.column(3).nodes().to$().show();
//      table.column(3).data().each((group: any, i: number) => {
//        if (group.date !== v) {
//          table.row(i).nodes().to$().hide();
//        }
//      });
//    } else {
//      table.column(3).search('').draw();
//      table.column(3).nodes().to$().show();
//    }
//  }
//}





//import { Component, OnInit } from '@angular/core';
//import { DatatableModel } from './datatablemodel.model';
//import { DatatableservicesService } from './datatableservices.service';
//declare var $: any;
//@Component({
//  selector: 'app-datatable',
//  templateUrl: './datatable.component.html',
//  styleUrls: ['./datatable.component.css']
//})
//export class DatatableComponent implements OnInit {
//  dynamicdata: DatatableModel[] = [];

//  constructor(private dataService: DatatableservicesService) { }

//  ngOnInit(): void {
//    this.getData()
//  }

//  getData(): void {
//    this.dataService.getData().subscribe(
//      data => {
//        this.dynamicdata = data;
//        setTimeout(() => {
//          $('#dataTables-example').DataTable({
//            pagingType: 'full_numbers',
//            pageLength: 5,
//            processing: true,
//            lengthMenu: [5, 10, 25]
//          });
//        }, 1);
//      },
//      error => console.error(error)
//    );
//  }

//  searchDate(ret: any): void {
//    const inputDate = ret.target.value; // getting search input value
//    const filteredData = this.dynamicdata.filter((data) => {
//      const dataDate = new Date(data.date); // converting date string to date object
//      const inputDateObj = new Date(inputDate);
//      return dataDate.getTime() === inputDateObj.getTime(); // comparing date objects
//    });
//    $('#dataTables-example').DataTable().clear().rows.add(filteredData).draw(); // updating table with filtered data
//  }
//}









import { Component, OnInit } from '@angular/core';
import { DatatableModel } from './datatablemodel.model';
import { DatatableservicesService } from './datatableservices.service';
declare var $: any;
@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.css']
})
export class DatatableComponent implements OnInit {
  dynamicdata: DatatableModel[] = [];

  constructor(private dataService: DatatableservicesService) { }

  ngOnInit(): void {
    this.getData()
  }
  getData(): void {
    this.dataService.getData().subscribe(
      data => {
        this.dynamicdata = data;
        setTimeout(() => {
          $('#dataTables-example').DataTable({
            pagingType: 'full_numbers',
            pageLength: 5,
            processing: true,
            lengthMenu: [5, 10, 25]
          });
        }, 1);
      },
      error => console.error(error)
    );
  }

  searchDate(ret: any): void {
    const v = ret.target.value; // getting search input value
    $('#dataTables-example').DataTable().columns(3).search(v).draw();
  }
}

