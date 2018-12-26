import { Component, OnInit } from '@angular/core';
import { FavorieService } from './favorie.service';
import { SessionService } from '../../auth/session.service';
import { Favorie } from '../../Models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-favorie',
  templateUrl: './favorie.component.html',
  styleUrls: ['./favorie.component.scss']
})
export class FavorieComponent implements OnInit {
  favories: Favorie[] = [];
  constructor(private service: FavorieService, public session: SessionService
    , private route: Router) { }

  ngOnInit() {
    this.getComments();
  }

  getComments(): void {
    this.service.getList(this.session.userID())
      .subscribe(favs => {
        console.log(favs);
        // favs.forEach(e => {
        //   e.ouvrier.imageUrl = atob(e.ouvrier.imageUrl);
        // });
        this.favories = favs;
        },
          e => console.error(e)
      );
  }

  public ouvrier(o: Favorie) {
    // this.data.user = o.idOuvrierNavigation;
    // this.idUser = o.idUser;
    this.route.navigate(['ouvrier', o.idOuvrier]);
  }

}
