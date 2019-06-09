import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { University } from '../model/university';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private httpClient: HttpClient) { }

  getUniversities(): Observable<University[]> {
    return <Observable<University[]>>
      this.httpClient.get(environment.getUniversities);
  }

  getPersonBySession(sessionId: string): Observable<Person> {
    return this.httpClient.get<Person>(environment.getPerson + encodeURIComponent(sessionId))
      .pipe(
        catchError(() => throwError({}))
      );
  }
}
