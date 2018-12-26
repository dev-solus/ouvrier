import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { SessionService } from '../../auth/session.service';
import { User } from '../../Models';


const API_URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})
export class OuvrierService {

  constructor(private http: HttpClient, private session: SessionService) { }
  //
  get(id) {
    return this.http.get(API_URL + 'users/' + id, {headers: this.session.getHeaders()}) as Observable<User>;
  }

}
