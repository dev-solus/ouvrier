import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User, Ville, Metier, Quartier, Location } from '../../Models';
import { SessionService } from '../../auth/session.service';
import { DataSearch } from './search.component';

const API_URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})

export class SearchService {
  // list: Quartier[];
  constructor(private http: HttpClient, public session: SessionService) { }
  // post
  get(o: DataSearch) {
    return this.http.get( API_URL + `Search/Get/${o.idVille}/ ${o.idQuartier}/ ${o.idMetier}`) as Observable<any>;
  }

  // list
  getVilles()  {
    return this.http.get(API_URL + `villes`, {headers: this.session.getHeaders()}) as Observable<Ville[]>;
  }
  // list
  getMetiers() {
    return this.http.get(API_URL + `metiers`, {headers: this.session.getHeaders()}) as Observable<Metier[]>;
  }
  //
  getQuartiers(idVille: number) {
    return this.http.get(API_URL + `quartiers/GetQuartiers/${idVille}`, {headers: this.session.getHeaders()}) as Observable<Quartier[]>;
  }
}

interface ResponceData {
  users: User[];
  locations: Location[];
}



