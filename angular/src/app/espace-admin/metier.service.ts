import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Metier } from '../Models';
import { SessionService } from '../auth/session.service';

const API_URL = environment.apiUrl + 'metiers';
@Injectable({
  providedIn: 'root'
})

export class MetierService {
  // list: Quartier[];
  constructor(private http: HttpClient, public session: SessionService) { }
  // post
  post(obj: Metier) {
    return this.http.post( API_URL, obj);
  }
  // updat
  put(obj: Metier) {
    return this.http.put(API_URL + '/' + obj.id, obj, {headers: this.session.getHeaders()});
  }
  // list
  getList(colToSort: string, orderBy: string, startIndex = 0, pageSize = 5) {
    return this.http.get(API_URL + `/GetAll/${colToSort}/ ${orderBy}/ ${startIndex}/ ${pageSize}`
    /*, {headers: this.session.getHeaders()}*/) as Observable<Reponce>;
  }
  // get recette
  get(id) {
    return this.http.get(API_URL + '/' + id, {headers: this.session.getHeaders()});
  }
  // delete
  delete(obj: Metier) {
    return this.http.delete(API_URL + '/' + obj.id, {headers: this.session.getHeaders()});
  }
}

interface Reponce {
  count: number;
  list: any[];
}



