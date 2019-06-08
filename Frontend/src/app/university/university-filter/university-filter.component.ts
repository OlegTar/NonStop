import { Component, OnInit } from '@angular/core';

import { DataService } from 'src/app/service/data.service';

@Component({
  selector: 'app-university-filter',
  templateUrl: './university-filter.component.html',
  styleUrls: ['./university-filter.component.css']
})
export class UniversityFilterComponent implements OnInit {

  constructor(protected dataService: DataService) { }

  ngOnInit() {
    this.getData();
  }

  private getData() {
    this.dataService.getUniversities().subscribe(res => {
      console.log(res);
    });
  }

}
