import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }
  getData(): Observable<any> {
    return this.http.get<any>('http://127.0.0.1:5000/api/getPartyOverview'); // Replace with your API endpoint
  }
}
