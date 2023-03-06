import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';
import { environment } from 'environments/environment';

const API_URL = environment.hubUrl + 'cv/';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  varHTML = `me <br> you <br>`;
  constructor(private service: HomeService) { }

  ngOnInit() {
    this.getFromApi();
  }

  getFromApi() {
    this.service.get().subscribe(
      r => {
        this.varHTML = r.aboutHTML;
      },
      e => console.log(e)
    );
  }

  download(linkCV: string) {
    console.log(API_URL + linkCV);
    const pwa = window.open(API_URL + linkCV);
    if (!pwa || pwa.closed || typeof pwa.closed === 'undefined') {
      alert('Please disable your Pop-up blocker and try again.');
    }
  }
}
