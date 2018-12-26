import { Component, OnInit, Input } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../../../environments/environment';
import { SessionService } from '../../../auth/session.service';
import { CommentService } from '../comment.service';

const API_URL = environment.hubUrl; // + 'Note'; // CommentHub
@Component({
  selector: 'app-count-comment',
  templateUrl: './comment-count.component.html',
  // styleUrls: ['./note-recette.component.css']
})
export class CountCommentComponent implements OnInit {
  @Input() idOuvrier: number;
  idChef: number;
  countComment = 0;
  styleBtn = 'primary'; //  btn-warning
  // hub
  private connection: HubConnection;

  constructor(public session: SessionService, public service: CommentService) {
    this.idChef = session.userID();
  }

  ngOnInit() {
    this.getCountComment();
    this.noteHubCnx();
  }

  getCountComment() {
    this.service.GetCountComment(this.idOuvrier)
    .subscribe(
      (r: number) => {
        this.countComment = r;
        this.setColor(r);
      },
      e => console.log(e)
    );
  }

  setColor(i: number) {
    if (i !== 0) {
      this.styleBtn = 'warn';
    }
  }

  noteHubCnx(): void {
    this.connection = new signalR.HubConnectionBuilder()
                                  .withUrl(API_URL + 'CountComment')
                                  .build();
    // connecter au hub
    this.connection.start().then(r => console.log(r)).catch(e => console.log(e));
    // attendre pour des mise a jour
    this.connection.on('BroadcastOne',
      (r: number) => {
        this.countComment += r;
      });
    // delete
      this.connection.on('DeleteOne',
      (r: number) => {
        this.countComment += r;
      }
    );
  }

}
