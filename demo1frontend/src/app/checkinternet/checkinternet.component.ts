import { Component, OnInit } from '@angular/core';
import { OnlineStatusService, OnlineStatusType } from 'ngx-online-status';

@Component({
  selector: 'app-checkinternet',
  templateUrl: './checkinternet.component.html',
  styleUrls: ['./checkinternet.component.css']
})
export class CheckinternetComponent implements OnInit {

  status!: OnlineStatusType;
  OnlineStatusType = OnlineStatusType;

  constructor(private onlineStatusService: OnlineStatusService) {
    this.onlineStatusService.status.subscribe((status: OnlineStatusType) => {
      // use status
      this.status = status;
    });
  }
  ngOnInit() { }
}
