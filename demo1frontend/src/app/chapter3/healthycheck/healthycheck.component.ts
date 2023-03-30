import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-healthycheck',
  templateUrl: './healthycheck.component.html',
  styleUrls: ['./healthycheck.component.css']
})
export class HealthycheckComponent implements OnInit {
  public result!: Result;
  isLoading = true;
  constructor(private http: HttpClient) {  }

  ngOnInit() {
    this.http.get<Result>('https://localhost:5001/hc')
      .subscribe(
        result => {
          this.result = result;
          this.isLoading = false;
        },
        error => {
          console.error('Error loading health check results', error);
          this.isLoading = false;
        }
      );
  }
}

interface Result {
  checks: Check[];
  totalStatus: string;
  totalResponseTime: number;
}

interface Check {
  name: string;
  status: string;
  responseTime: number;
  description: string;
}

