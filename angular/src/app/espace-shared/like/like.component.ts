import { Component, OnInit, Input } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { environment } from '../../../environments/environment';
import { SessionService } from '../../auth/session.service';
import * as signalR from '@microsoft/signalr';
import { LikeService } from './like.service';
import { Likeuser } from '../../Models';

const API_URL = environment.hubUrl; // + 'Note'; // CommentHub
@Component({
  selector: 'app-like',
  templateUrl: './like.component.html',
  styleUrls: ['./like.component.scss']
})

export class LikeComponent implements OnInit {
  @Input() idOuvrier: number;
  idUser: number;
  liked = 0; // soit 0 ou 1
  // noteCHef = 0;
  totalLike = 0;
  styleBtn = 'primary';
  // hub
  connection: any;

  constructor(public session: SessionService, public service: LikeService) {
    this.idUser = session.userID();
  }

  ngOnInit() {
    this.getLikesByOuvrier();
    this.checkJaime();
    this.noteHubCnx();
    // this.getCountComment();
  }

  checkJaime() {
    this.service.checkUserLikes(this.idOuvrier, this.idUser)
      .subscribe(
        (r: number) => {
          this.liked = r;
          if (this.liked === 1) {
            this.styleBtn = 'warn';
          } else {
            this.styleBtn = 'primary';
          }
        },
        e => console.log(e)
      );
  }

  getLikesByOuvrier() {
    this.service.getCountLikesPerUser(this.idOuvrier)
      .subscribe(
        (r: number) => {
          // console.log('noteRecette ' + this.noteRecette);
          this.totalLike = r;
      },
      e => console.log(e)
    );
  }

  // getCountComment() {
  //   this.service.GetCountComment(this.idCategorie);
  // }

  jaime() {
    console.log('this.liked = ', this.liked);
    if (this.liked === 0) {
      this.add();
    } else {
      this.delete();
    }
  }

  add() {
    const obj: Likeuser = {idOuvrier: this.idOuvrier, idUser: this.idUser, note: 1};
    this.service.post(obj)
      .subscribe(
        r => {
          this.liked = 1;
          this.styleBtn = 'warn';
        },
        e => console.log(e)
      );
  }

  delete() {
    this.service.delete(this.idOuvrier, this.idUser)
      .subscribe(
        r => {
          this.liked = 0;
          this.styleBtn = 'primary';
        },
        e => console.log(e)
      );
  }

  noteHubCnx(): void {
    this.connection = new signalR.HubConnectionBuilder()
    .withUrl(API_URL + 'like')
    .build();
    // this.connection = new HubConnection();
    // wait for server call
  //   this.connection.on('send', data => {
  //     console.log(data);
  // });
    // connecter au hub
    this.connection.start().then(r => console.log(r)).catch(e => console.log(e));
    // this.connection.start()
    // .then(() => this.connection.invoke('send', 'Hello'));
    // attendre pour des mise a jour
    this.connection.on('BroadcastLike',
      (idOuvrierToAddLike: number) => {
        if (idOuvrierToAddLike === this.idOuvrier) {
          this.totalLike += 1;
        }
      });
    // delete
      this.connection.on('DeleteLike',
      (idOuvrierToAddLike: number) => {
        if (idOuvrierToAddLike === this.idOuvrier) {
          this.totalLike -= 1;
        }
      }
    );
  }
}
