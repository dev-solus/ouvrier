import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { About } from './edit-about/edit-about.component';

const API_URL = environment.apiUrl + 'about';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }
  //
  post(o) {
    return this.http.post(API_URL, o);
  }

  get() {
    return this.http.get(API_URL) as Observable<About>;
  }

  postFile(file: any) {
    return this.http.post(API_URL + '/postFile', file) as Observable<any>;
  }

}
