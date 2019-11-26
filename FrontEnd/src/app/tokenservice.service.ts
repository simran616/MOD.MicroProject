import { Injectable, Injector } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpInterceptor } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class TokenserviceService implements HttpInterceptor {

  constructor( private injector: Injector) { }

  intercept( req, next) {
    let token = localStorage.getItem('token')
    let tokenizedReq = req.clone({
      setHeaders : {
        Authorization : `Bearer ${token}`
        // Authorization : 'Bearer xx.xx.xx'
      }
    })
    return next.handle(tokenizedReq)
  }
}