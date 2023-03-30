import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AuthorizeService } from '../authorize.service';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {

  public isAuthenticated!: Observable<boolean>;
  public userName!: Observable<string>;

  constructor(private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u?.name ?? ''));
  }

}
