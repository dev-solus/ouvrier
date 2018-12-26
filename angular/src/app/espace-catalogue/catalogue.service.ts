import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Catalogue } from '../Models';
import { SessionService } from '../auth/session.service';

const API_URL = environment.apiUrl + 'Catalogues';
@Injectable({
  providedIn: 'root'
})

export class CatalogueService {
  // list: Quartier[];
  constructor(private http: HttpClient, public session: SessionService) { }
  // post
  post(obj: any) {
    return this.http.post(API_URL, obj);
  }

  postFile(file: any) {
    return this.http.post(API_URL + '/postFile', file) as Observable<any>;
  }
  // updat
  put(obj: Catalogue) {
    return this.http.put(API_URL + '/' + obj.id, obj, { headers: this.session.getHeaders() });
  }
  //
  getList0(idUser = 0) {
    return this.http.get(API_URL + '/GetCatalogues/' + idUser, { headers: this.session.getHeaders() });
  }
  // list
  getList(idUser = 0, startIndex = 0, pageSize = 10) {
    return this.http.get(API_URL + `/GetCatalogues/${idUser}/${startIndex}/${pageSize}`
    , {headers: this.session.getHeaders()}) as Observable<Reponce>;
  }
  // get catalogue
  get(id) {
    return this.http.get(API_URL + '/' + id, { headers: this.session.getHeaders() });
  }
  //
  getArticles(id: number) {
    return this.http.get(API_URL + `Articles/GetArticles/` + id, { headers: this.session.getHeaders() }) as Observable<any[]>;
  }
  // delete
  delete(id: number) {
    return this.http.delete(API_URL + '/' + id, { headers: this.session.getHeaders() });
  }

  // // delete
  // deleteArticle(id: number) {
  //   return this.http.delete(API_URL + 'Articles/' + id, { headers: this.session.getHeaders() });
  // }
}
interface Reponce {
  count: number;
  list: any[];
}



