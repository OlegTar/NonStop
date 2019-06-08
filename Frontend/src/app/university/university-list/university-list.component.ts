import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { University } from 'src/app/model/university';
import { Observable, Subscription } from 'rxjs';
import { DataService } from 'src/app/service/data.service';
import { map } from 'rxjs/operators';
import { Specialization } from 'src/app/model/specialization';

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
    protected cdr: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.sub = new Subscription();
    this.getData();
  }

  private getData() {
    this.sub.add(
      this.dataService.getUniversities().subscribe((u: University[]) => {
        this.universities = u;
        this.cdr.markForCheck();
      })
    );
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
