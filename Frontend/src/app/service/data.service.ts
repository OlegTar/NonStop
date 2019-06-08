import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private httpClient: HttpClient) { }

  getUniversities() {
    return this.httpClient.get(environment.getUniversities).pipe(
      map(res => {
        console.log(res);
      })
    );
  }
}
