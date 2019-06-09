import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { University } from 'src/app/model/university';
import { Observable, Subscription } from 'rxjs';
import { DataService } from 'src/app/service/data.service';
import { map } from 'rxjs/operators';
import { Specialization } from 'src/app/model/specialization';
import { Router } from '@angular/router';

@Component({
  selector: 'app-university-list',
  templateUrl: './university-list.component.html',
  styleUrls: ['./university-list.component.css']
})
export class UniversityListComponent implements OnInit, OnDestroy {

  universities: University[];
  sub: Subscription;
  
  constructor(
    protected dataService: DataService,
    protected cdr: ChangeDetectorRef,
    protected router: Router
  ) { }

  ngOnInit() {
    this.sub = new Subscription();
    this.getData();
  }

  goTo(path: string) {
    window.location.href = path;
  }

  private getData() {
    this.sub.add(
      this.dataService.getUniversities().subscribe((u: University[]) => {
        this.universities = u;
        this.cdr.markForCheck();
      })
    );
  }

  navigateTo(id) {
    this.router.navigateByUrl('/university/' + id);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
