import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { LocalStorageService } from '../local-storage/local-storage.service';
@Injectable({
  providedIn: 'root'
})
export class JWTTokenService {

  private jwtToken?: string;
  private decodedToken?: { [key: string]: any; };
  constructor(private localStorageService:LocalStorageService) { }

  setToken(token: string) {
    if (token) {
      this.jwtToken = token;
    }
  }
  decodeToken() {
    this.jwtToken = this.localStorageService.get('access_token');
    if (this.jwtToken ) {
      this.decodedToken = jwt_decode(this.jwtToken);
    }
  }
  getDecodeToken() {
    this.decodeToken();
    return this.decodedToken;
  }
  getUser() {
    this.decodeToken();
    return this.decodedToken ? this.decodedToken['unique_name'] : null;
  }
  getExpiryTime() {
    this.decodeToken();
    return this.decodedToken ? this.decodedToken['exp'] : null;
  }

  isTokenExpired(): boolean {
    const expiryTime:number = this.getExpiryTime();
    if (expiryTime) {
      return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
    } else {
      return false;
    }
  }
}
