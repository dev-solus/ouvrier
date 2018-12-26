import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { SessionService } from '../../auth/session.service';
import { Favorie } from '../../Models';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'Favories';
@Injectable({
  providedIn: 'root'
})

export class FavorieService {
  constructor(private http: HttpClient, public session: SessionService) { }

  getList(idUser: number) {
    return this.http.get(API_URL + '/GetFavories/' + idUser, {headers: this.session.getHeaders()}) as Observable<Favorie[]>;
  }

  post(obj: Favorie) {
    return this.http.post( API_URL , obj);
  }

  // delete
  delete(idOuvrier: number, idUser: number) {
    return this.http.delete(`${API_URL}/DeleteFavorie/${idOuvrier}/${idUser}`, {headers: this.session.getHeaders()});
  }

  public getState(idOuvrier: number, idUser: number) {
    return this.http.get(`${API_URL}/getState/${idOuvrier}/${idUser}`, {headers: this.session.getHeaders()});
  }
}




