import { Component, OnInit, Input, OnChanges, Output } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder } from '@angular/forms';
import { HubConnection } from '@aspnet/signalr';
import { AppConfig } from '../../app.config';
import { Commentaire, User } from '../../Models';
import { SessionService } from '../../auth/session.service';
import { CommentService } from './comment.service';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../../environments/environment';

const API_URL = environment.hubUrl; // + 'Note'; // CommentHub
@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  // this mate come from the outside. thankyou then
  @Input() idOuvrier: number;
  myForm: UntypedFormGroup;
  comments: Commentaire[];
  o: Commentaire = new Commentaire();
  private connection: HubConnection;
  idUserConnecter = 1;
  // chef: Chef;
  isReadonly = true;
  // isReplying = false;

  constructor(private fb: UntypedFormBuilder, private commentService: CommentService,
    public session: SessionService/*, private noteService: NoteService*/) {
      // this.commentCount += 1;
  }


  ngOnInit() {
    this.getComments();
    this.commentHubCnx();
    this.createForm();
  }

  getComments(): void {
    this.commentService.getList(this.idOuvrier)
      .subscribe(
        comments => {
          console.log(comments);
          // comments.forEach(e => {
          //   e.user.imageUrl = atob(e.user.imageUrl);
          // });
          this.comments = comments;
        },
          e => console.error(e) );
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      idOuvrier: this.idOuvrier,
      idUser: this.session.userID(),
      comment: this.o.comment,
      date: new Date(),
      user: this.session.user,
    });
  }

  getMyCommnent(idUser: number): boolean {
    return this.session.userID() === idUser;
  }

  onSubmit(myForm: UntypedFormGroup) {
    const obj: Commentaire = myForm.value;
    // obj.idUser = this.session.userID();
    obj.user = this.session.user;
    this.commentService.post(obj)
      .subscribe(
        responce => {
          console.log(responce);
          this.createForm();
        },
        error => console.log(error)
      );
  }


  edit(c: Commentaire) {
    if (c.comment === '') {
      return;
    }
    if (!this.isReadonly) { // le text area est modifiable
      this.commentService.put(c.id, c)
      .subscribe(
        responce => console.log('responce = ' + responce),
        error => console.log('error = ' + error.status)
      );
      this.isReadonly = true;
    } else {
      this.isReadonly = false;
    }
  }

  delete(id: number) {
    this.commentService.delete(id)
    .subscribe(
      responce => console.log('responce = ' + responce),
      error => console.log('error = ' + error.status)
    );
  }


  commentHubCnx(): void {
    // this.connection = new signalR.HubConnection('http://localhost:62124/CommentHub', { logger: signalR.LogLevel.Trace });
    this.connection = new signalR.HubConnectionBuilder()
    .withUrl(API_URL + 'CommentHub')
    .build();
    // connecter au hub
    this.connection.start().then(r => console.log('Signal work')).catch(e => console.log(e));

    // attendre pour des mise a jour
    this.BroadcastComment();
    this.EditComment();
    this.DeleteComment();
  }
  //
  BroadcastComment(): void {
    this.connection.on('BroadcastComment',
      (id: number, commentaire: Commentaire, user: User) => {
        // this.msgs.push({ severity: type, summary: payload });
        // console.log('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> comment');
        // console.log(commentaire);
        commentaire.user = user;
        // commentaire.user.imageUrl = atob(commentaire.user.imageUrl);
        this.comments.push(commentaire);
        // this.noteService.countComment += 1;
        // console.log('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>');
        // this.createForm();
      }
    );
  }
  //
  EditComment(): void {
    this.connection.on('EditComment',
      (id: number, commentaire: Commentaire) => {
        // this.msgs.push({ severity: type, summary: payload });
        // console.log('id: ' + id + ', description: ' + commentaire.description);
        let i = 0;
        i = this.comments.findIndex(c => c.id === id);
        this.comments[i].comment = commentaire.comment;
        this.comments[i].date = commentaire.date;
        // this.recetteA.commentaires.push(commentaire);
        this.createForm();
      }
    );
  }
  //
  DeleteComment(): void {
    this.connection.on('DeleteComment',
      (id: number, commentaire: Commentaire) => {
        // this.msgs.push({ severity: type, summary: payload });
        // console.log('id: ' + id + ', description: ' + commentaire.description);
        let i = 0;
        i = this.comments.findIndex(c => c.id === id);
        this.comments.splice(i, 1);
        // console.log('<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<');
        // this.noteService.countComment -= 1;
        // this.recetteA.commentaires.push(commentaire);
        this.createForm();
      }
    );
  }
      // this.recetteA.commentaires.push(commentForm.value as Commentaire);
      // this.createForm();
    // recetteForm.value.idChef = 1;
    // recetteForm.value.imgUrl = btoa(this.imgUrl);
    // console.log('recetteForm.value.Preparations[0].description = ' + recetteForm.value.Preparations[0].description);
    // this.recetteService.put(<number>recetteForm.value.id, <Recette>recetteForm.value)
    // .subscribe(
    //   succes => {
    //     console.log('succes = ' + succes);
    //   },
    //   error => {
    //     console.log('error = ' + error.status);
    //   });

    // console.log('submit est fait');
}
