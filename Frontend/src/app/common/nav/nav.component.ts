import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from 'src/app/service/data.service';
import { Observable, of } from 'rxjs';
import { catchError, take, filter } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  person$: Observable<Person>;
  person: Person;

  constructor(private cookie: CookieService, private dataService: DataService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

  ngOnInit() {
    const sessionId = this.cookie.get('sessionId');
    if (sessionId != null && sessionId !== '') {
      this.dataService.getPersonBySession(sessionId).pipe(catchError(() => {
        return of(null);
      })).pipe(take(1)).subscribe(p => {
        this.person = p;
        this.cdr.markForCheck();
      });
    }
  }

  logout() {
    this.cookie.delete('sessionId');
    this.person = null;
    this.router.navigateByUrl('/', { replaceUrl: true });
  }

}
