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
  displayedColumns: string[] = ['position', 'surname', 'name', 'patronymic', 'nameSpecialization', 'numberPoints'];
  dataSource = ELEMENT_DATA;
}
export interface PeriodicElement {
  position: Number;
  surname: string;
  name: string;
  patronymic: string;
  nameSpecialization: string;
  numberPoints: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, surname: 'Иванов', name: 'Иван', patronymic: 'Иванович', nameSpecialization: 'Математика', numberPoints: '256'},
  { position: 2, surname: 'Иванов', name: 'Иван', patronymic: 'Иванович', nameSpecialization: 'Биология', numberPoints: '230'},
  { position: 3, surname: 'Иванов', name: 'Иван', patronymic: 'Иванович', nameSpecialization: 'Физика', numberPoints: '190'},
];

