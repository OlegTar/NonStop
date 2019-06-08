import { Component, OnInit } from '@angular/core';
import { University } from 'src/app/model/university';

@Component({
  selector: 'app-university-list',
  templateUrl: './university-list.component.html',
  styleUrls: ['./university-list.component.css']
})
export class UniversityListComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  cards: University[] = [
    {
      name: 'Санкт-Петербургский университет Петра Великого',
      description: 'съешь же ещё этих мягких французских булок, да выпей чаю'
    },
    {
      name: 'Санкт-Петербургский университет Петра Великого',
      description: 'съешь же ещё этих мягких французских булок, да выпей чаю'
    },
    {
      name: 'Санкт-Петербургский университет Петра Великого',
      description: 'съешь же ещё этих мягких французских булок, да выпей чаю'
    }
  ];

}
