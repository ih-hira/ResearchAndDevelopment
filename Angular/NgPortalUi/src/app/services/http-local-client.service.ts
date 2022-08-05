import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "../../environments/environment";
@Injectable({
  providedIn: 'root'
})
export class HttpLocalClientService {

  public BASE_URL: string;
  constructor(private http: HttpClient) {
    this.BASE_URL = environment.base_url;
  }

  get<R>(url: string) {
    return this.http.get<R>(this.BASE_URL + url, this.getHeaders());
  }
  getByQueryParams<T, R>(url: string, data: T) {
    return this.http.get<R>(this.BASE_URL + url, this.getHeaders<T>(data));
  }
  post<T, R>(url: string, data: T) {
    return this.http.post<R>(this.BASE_URL + url + "?", data, this.getHeaders());
  }
  put<T, R>(url: string, data: T) {
    return this.http.put<R>(this.BASE_URL + url, data, this.getHeaders());
  }
  delete<R>(url: string) {
    return this.http.delete<R>(this.BASE_URL + url, this.getHeaders());
  }
  deleteT<T, R>(url: string, data: T) {
    const options = { ...this.getHeaders(), body: data }
    return this.http.delete<T>(this.BASE_URL + url, options);
  }
  private getHeaders<T>(searchObj?: T) {
    const headers = new HttpHeaders({
      // "Content-Type": "application/json",
      // "Authorization": "bearer " + this.token,
    });
    let headerObj: any = { headers: headers, reportProgress: true };
    if (searchObj) {
      headerObj.params = searchObj;
    }
    return headerObj;
  }
}
