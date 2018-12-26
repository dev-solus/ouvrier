import { Injectable } from '@angular/core';
import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { CatalogueService } from '../catalogue.service';
import { Catalogue } from '../../Models';
// import { Observable } from 'rxjs/Observable';

@Injectable({
    providedIn: 'root'
  })
export class EditResolve implements Resolve<any> {

  constructor(private serviceData: CatalogueService) { }

  //
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    // console.log('route.params[id] = ' + route.params['id']);
    return this.serviceData.get( route.params['id']) as Observable<Catalogue>;
  }
}
