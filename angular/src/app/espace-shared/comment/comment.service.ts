import { Injectable } from '@angular/core';
import { AppConfig } from '../../app.config';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { SessionService } from '../../auth/session.service';
import { Commentaire } from '../../Models';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl + 'Commentaires';
@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient, private session: SessionService) { }
  // post
  post(comment: Commentaire) {
    return this.http.post( API_URL, comment, {headers: this.session.getHeaders()});
  }

  // updat
  put(id, comment: Commentaire) {
    return this.http.put(API_URL + '/' + id, comment, {headers: this.session.getHeaders()});
  }

  // get recette
  get(id) {
    return this.http.get(API_URL + '/' + id, {headers: this.session.getHeaders()});
  }

  // list
  getList(id: number) {
    return this.http.get(API_URL + '/GetCommentaires/' + id, {headers: this.session.getHeaders()}) as Observable<Commentaire[]>;
  }

  // delete
  delete(id: number) {
    return this.http.delete(API_URL + '/' + id, {headers: this.session.getHeaders()});
  }

  public GetCountComment(idOuvrier: number) {
    return this.http.get(API_URL + '/GetCountComment/' + idOuvrier, {headers: this.session.getHeaders()});
  }

}
