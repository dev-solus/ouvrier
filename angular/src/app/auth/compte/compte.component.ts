import { Component, OnInit, Injectable } from '@angular/core';
import { SessionService } from '../../auth/session.service';
import { User } from '../../Models';
import { AuthService } from '../auth.service';
import { ActivatedRouteSnapshot, Resolve, ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-compte',
  templateUrl: './compte.component.html',
  styleUrls: ['./compte.component.scss']
})
export class CompteComponent implements OnInit {
  user: User = new User();
  constructor(private compteService: AuthService, public session: SessionService
    , private route: ActivatedRoute, public router: Router) {
    // this.getUser();
   }

  ngOnInit() {
    this.getObjectFromRouteResolver();
  }

  // getUser() {
  //   console.log('this.session.userID() = ', this.session.userID());
  //   this.compteService.get(this.session.userID())
  //   .subscribe(
  //     r => {
  //       console.log('r = ', r);
  //       this.user = r;
  //       // this.user.imageUrl = atob(this.user.imageUrl);
  //     },
  //     e => {
  //       console.log(e);
  //     }
  //   );
  // }

  getObjectFromRouteResolver() {
    this.route.data.subscribe(
      r => {
        this.user = <User>r['mydata'];
        // console.log(this.o);
      }, e => {
        // console.log(e);
        this.router.navigate(['']);
      }
    );
  }

  // put(o: FormData) {
  //   const jwt = 'mourabit';
  //   // console.log(o.get('object'));
  //   // return;
  //   this.service.put(this.o._id, o)
  //     .subscribe(r => {
  //       // console.log(r);
  //       this.session.doSignIn(jwt, r);
  //       this.router.navigate(['recette/all']);
  //     }, e => {
  //       console.log(e);
  //     });
  // }

}

@Injectable({
  providedIn: 'root'
})
export class MyResolve implements Resolve<Observable<User>> {

  constructor(public service: AuthService) { }

  public resolve(route: ActivatedRouteSnapshot) {
    console.log(route.paramMap.get('id'));
    return this.service.get(route.paramMap.get('id')) as Observable<User>;
  }

}
