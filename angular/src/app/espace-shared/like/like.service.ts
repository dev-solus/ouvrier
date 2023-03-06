import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SessionService } from "app/auth/session.service";
import { environment } from "environments/environment";
import { Observable } from "rxjs";



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
