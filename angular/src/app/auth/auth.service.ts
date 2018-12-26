import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { TokenInterface } from './TokenInterface';
import { User, Ville, Metier, Quartier } from '../Models';
import { SessionService } from './session.service';

const API_URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})

export class AuthService {
  // list: Quartier[];
  constructor(private http: HttpClient, public session: SessionService) { }

  authenticate(model) {
    return this.http.post(API_URL + 'Users/authenticate', model) as Observable<TokenInterface>;
  }

  postFile(file: any) {
    return this.http.post(API_URL + 'Users/postFile', file) as Observable<any>;
  }

  // post
  register(obj: User) {
    return this.http.post( API_URL + 'users/register', obj);
  }
  // updat
  put(obj: User) {
    return this.http.put(API_URL + 'users/' + obj.id, obj);
  }
  // list
  getVilles()  {
    return this.http.get(API_URL + `villes`) as Observable<Ville[]>;
  }
  // list
  getMetiers() {
    return this.http.get(API_URL + `metiers`) as Observable<Metier[]>;
  }
  //
  getQuartiers(idVille: number) {
    return this.http.get(API_URL + `quartiers/GetQuartiers/${idVille}`) as Observable<Quartier[]>;
  }
  // get recette
  get(id) {
    return this.http.get(API_URL + 'users/' + id) as Observable<User>;
  }


  // get(id) {
  //   this.session.userID();
  //   return this.http.get(API_URL + 'users/' + id) as Observable<User>;
  // }
}



