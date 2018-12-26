import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Quartier, Ville } from '../Models';
import { environment } from '../../environments/environment';
import { SessionService } from '../auth/session.service';

const API_URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})

export class QuartierService {
  list: Quartier[];
  constructor(private http: HttpClient, public session: SessionService) { }
  // post
  post(quartier: Quartier) {
    return this.http.post(API_URL + 'quartiers', quartier);
  }
  // updat
  put(quartier: Quartier) {
    return this.http.put(API_URL + 'quartiers/' + quartier.id, quartier, { headers: this.session.getHeaders() });
  }
  // list
  // list
  getList(colToSort: string, orderBy: string, startIndex = 0, pageSize = 5) {
    return this.http.get(API_URL + `quartiers/getFive/${colToSort}/ ${orderBy}/ ${startIndex}/ ${pageSize}`
    /*, {headers: this.session.getHeaders()}*/) as Observable<Reponce>;
  }
  // list
  getVilles() {
    return this.http.get(API_URL + `villes`, { headers: this.session.getHeaders() }) as Observable<Ville[]>;
  }
  // get recette
  get(id) {
    return this.http.get(API_URL + '/' + id, { headers: this.session.getHeaders() });
  }
  // delete
  delete(o: Quartier) {
    return this.http.delete(API_URL + 'quartiers/' + o.id, { headers: this.session.getHeaders() });
  }
}

interface Reponce {
  count: number;
  list: any[];
}



