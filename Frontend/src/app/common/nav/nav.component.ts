import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from 'src/app/service/data.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  person$: Observable<Person>;
  person: Person;

  constructor(private cookie: CookieService, private dataService: DataService) { }

  ngOnInit() {
    const sessionId = this.cookie.get('sessionId');
    console.log(sessionId);
    if (sessionId != null && sessionId !== '') {
      this.person$ = this.dataService.getPersonBySession(sessionId);
    }
  }

}
