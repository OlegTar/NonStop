import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-commision',
  templateUrl: './commision.component.html',
  styleUrls: ['./commision.component.css']
})
export class CommisionComponent implements OnInit {
  constructor() { }
  ngOnInit() {
  }
  selected = 'Факультет 1';
  displayedColumns: string[] = ['position', 'surname', 'numberPoints'];
  dataSource = ELEMENT_DATA;
}
export interface PeriodicElement {
  position: Number;
  surname: string;
  numberPoints: Number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, surname: 'Емельянова А.В.', numberPoints: 262 },
  { position: 2, surname: 'Дуров Т.В.', numberPoints: 261 },
  { position: 3, surname: 'Смирнов А.Е.',  numberPoints: 259 },
  { position: 4, surname: 'Кузнецов В.Р.',  numberPoints: 259 },
  { position: 5, surname: 'Попов Ч.С.',  numberPoints: 259 },
  { position: 6, surname: 'Васильев З.Ш.',  numberPoints: 259 },
  { position: 7, surname: 'Соколов П.М.',  numberPoints: 259 },
  { position: 8, surname: 'Михайлов Ж.Х.',  numberPoints: 259 },
  { position: 9, surname: 'Новиков В.А.',  numberPoints: 259 },
];
