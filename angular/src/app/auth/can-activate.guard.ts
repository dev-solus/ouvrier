// import { AuthService } from './auth.service';
// import { Injectable } from '@angular/core';
// import { Router, CanActivate } from '@angular/router';
// @Injectable()
// export class AuthGuard implements CanActivate {

//   constructor(private authService: AuthService, private router: Router) { }

//   canActivate() {

//     console.log('bool = ' + this.authService.IsloggedIn());
//     if (!this.authService.IsloggedIn()) {
//        this.router.navigate(['/auth/signin']);
//        return false;
//     }

//     return true;
//   }
// }

import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { SessionService } from './session.service';

@Injectable()
export class CanActivateGuard implements CanActivate {

  constructor(private session: SessionService, private router: Router) {
  }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot ): Observable<boolean> | Promise<boolean> | boolean {

    if (!this.session.IsloggedIn()) {
      this.router.navigate(['auth/signin']);
      return false;
    }
    return true;
  }

}
