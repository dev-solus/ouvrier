import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { User } from '../Models';

const KEYTOKEN = 'TOKEN';
const KEYUSER = 'USER';
@Injectable({
  providedIn: 'root'
})
export class SessionService {
  public accessToken: string;
  public user: User;
  private headers: HttpHeaders;

  constructor() {
    this.getSession();
  }

  public userName() {
    if (this.user) {
      return `${this.user.username} ${this.user.lastName}`;
    }
    return 'User';
  }

  public userID() {
    if (this.user) {
      return this.user.id;
    }
    return 0;
  }

  public isAdmin(): boolean {
    if (this.user && this.user.role === 2008) {
      return true;
    }
    return false;
  }

  public userImg(): string {
    // console.log(this.session.chef.imgUrl);
    if (this.user && this.user.imageUrl) {
      return this.user.imageUrl;
    }
    return '../assets/user.png';
  }


  // se connecter
  public doSignIn(token: string, user: User) {
    if ((!token) || (!user)) {
      return;
    }
    this.user = user;
    this.accessToken = token;
    console.log(this.user);
    localStorage.clear();
    localStorage.setItem(KEYTOKEN, token);
    localStorage.setItem(KEYUSER, JSON.stringify(user));
  }

  // se deconnecter
  public doSignOut(): void {
    // remove user from local storage to log user out
    this.accessToken = null;
    this.user = null;
    this.headers = null;
    localStorage.removeItem(KEYTOKEN);
    localStorage.removeItem(KEYUSER);
  }

  // this methode is for our auth guard
  public IsloggedIn(): boolean {
    // console.log(!!localStorage.getItem(KEYUSER) && !!localStorage.removeItem(KEYTOKEN));
    return !!localStorage.getItem(KEYUSER) && !!localStorage.getItem(KEYTOKEN);
  }

  //
  public getSession(): void {
    if (localStorage.getItem(KEYTOKEN) && localStorage.getItem(KEYUSER)) {
      this.accessToken = localStorage.getItem(KEYTOKEN);
      this.user = JSON.parse(localStorage.getItem(KEYUSER));
    }
  }


  // get header for http request need autorized
  public getHeaders(): HttpHeaders {
    if (this.accessToken) {
      this.headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + this.accessToken
      });
    }
    return this.headers;
  }
}
