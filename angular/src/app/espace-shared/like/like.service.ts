import { Injectable } from '../../../../node_modules/@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from '../../../../node_modules/rxjs';
import { HttpClient } from '../../../../node_modules/@angular/common/http';
import { SessionService } from '../../auth/session.service';


const API_URL = environment.apiUrl + 'Likeusers';
@Injectable({
  providedIn: 'root'
})
export class LikeService {

  constructor(private http: HttpClient, private session: SessionService) { }

  public post(obj: any) {
    return this.http.post(API_URL, obj, {headers: this.session.getHeaders()});
  }

  public delete(idOuvrier: number, idUser: number): Observable<any> {
    return this.http.delete(API_URL + '/DeleteLikeuser/' + idOuvrier + '/' + idUser, {headers: this.session.getHeaders()});
  }
  //
  public getCountLikesPerUser(id: number): Observable<any> {
    return this.http.get(API_URL + '/GetCountLikePerUser/' + id, {headers: this.session.getHeaders()});
  }

  public checkUserLikes(idOuvrier: number, idUser: number): Observable<any> {
    return this.http.get(API_URL + '/CheckUserLikes/' + idOuvrier + '/' + idUser, {headers: this.session.getHeaders()});
  }

}
