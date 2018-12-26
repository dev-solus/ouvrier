import { Component, OnInit, OnDestroy } from '@angular/core';
import { SessionService } from '../../auth/session.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {

  // catalogues: Catalogue[] = [];
  // idToDelete: number;
  actuelUser = this.session.userID();
  idUser: number;
  constructor(private session: SessionService, private route: ActivatedRoute) {
    // this.idUser = this.session.userID();
    this.route.params.subscribe(params => {
      this.idUser = params['id'];
    });
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
  }
}
