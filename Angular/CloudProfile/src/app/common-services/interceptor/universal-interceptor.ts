import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Inject, Optional } from '@angular/core';
import { LocalStorageService } from '../local-storage/local-storage.service';
@Injectable()
export class UniversalAppInterceptor implements HttpInterceptor {

  constructor( private localStorageService: LocalStorageService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = this.localStorageService.get('access_token');
    req = req.clone({
      url:  req.url,
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next.handle(req);
  }
}