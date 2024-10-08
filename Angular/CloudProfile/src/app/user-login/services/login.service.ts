import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { catchError, Observable, throwError } from 'rxjs';
import { Constants } from 'src/app/config/constants';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  result: any = null;
  apiBaseUrl = Constants.API_BASE_URL;
  constructor(private httpClient: HttpClient) { }

  userLogin(userCred: JSON) {
    const url = `${this.apiBaseUrl}api/Auth/Login`;
    return this.httpClient.post(url, userCred).pipe(catchError(this.handleError));
  }
  refreshTokenCallBack() {
    return new Promise((e) => e);
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
        default:
          errorMessage = error.message
          break;
      }
    }
    //window.alert(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}
