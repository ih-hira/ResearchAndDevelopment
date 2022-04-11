import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { Constants } from 'src/app/config/constants';
import { UserDetails } from '../view-model/user-details.model';

@Injectable()
export class UserDetailsService {
  apiBaseUrl = Constants.API_BASE_URL;
  constructor(private httpClient: HttpClient) { }

  getUserByUserName(username: string): Observable<UserDetails> {
    const url = `${this.apiBaseUrl}api/User/UserDetails/${username}`;
    return this.httpClient.get<UserDetails>(url).pipe(map((data: UserDetails) => { return data; }), catchError(this.handleError));
  }
  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      switch (error.status) {
        case 401:
          errorMessage = "Invalid username or password!!"
          break;
        case 400:
          errorMessage = "User not found"
          break;
        default:
          errorMessage = error.message
          break;
      }
    }
    //window.alert(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}
