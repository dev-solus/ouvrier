import { Component, OnInit, Input } from '@angular/core';
import { FavorieService } from '../favorie.service';
import { SessionService } from '../../../auth/session.service';
import { Favorie } from '../../../Models';

@Component({
  selector: 'app-update-favorie',
  templateUrl: './update-favorie.component.html',

})
export class UpdateFavorieComponent implements OnInit {
  // favories: Favorie[] = [];
  // @Input() fav: Favorie;
  // idUser: number;
  @Input() idOuvrier: number;
  added = 0;
  styleBtn = 'primary';
  constructor(private service: FavorieService, public session: SessionService) { }

  ngOnInit() {
    this.checkAdd();
  }


  checkAdd() {
    this.service.getState(this.idOuvrier, this.session.userID())
      .subscribe(
        (r: number) => {
          console.log(r);
          this.added = r; // r soit 1 ou 0
          if (this.added === 1) {
            this.styleBtn = 'warn';
          } else {
            this.styleBtn = 'primary';
          }
        },
        e => console.log(e)
      );
  }

  addToCarnet() {
    if (this.added === 0) {
      this.add();
    } else {
      this.delete();
    }
  }

  add() {
    this.service.post({idOuvrier: this.idOuvrier, idUser: this.session.userID()} as Favorie)
      .subscribe(
        r => {
          this.added = 1;
          this.styleBtn = 'warn';
        },
        e => console.log(e)
      );
  }

  delete() {
    this.service.delete(this.idOuvrier, this.session.userID())
      .subscribe(
        r => {
          this.added = 0;
          this.styleBtn = 'primary';
        },
        e => console.log(e)
      );
  }

}
