import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { SessionService } from '../auth/session.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  public isLoading = false;

  constructor(public session: SessionService, private router: Router) {
  }

  ngOnInit() {
  }

  isSignedIn(): boolean {
    return this.session.IsloggedIn();
  }

  private nameUser(): string {
    return this.session.user.username; // .userName();
  }

  public userName(): string {
    return this.session.userName();
  }

  get userImg(): string {
    return this.session.userImg();
  }

  logOut(): void {
    this.session.doSignOut();
    this.router.navigate(['/catalogues/all']);
  }

  isAdmin(): boolean {
    return this.session.isAdmin();
  }

  isOuvrier(): boolean {
    if (this.session.user.type === 'simple') {
      return false;
    }
    return true;
  }

}
