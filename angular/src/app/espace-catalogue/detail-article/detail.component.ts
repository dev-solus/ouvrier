import { Component, OnInit, Injectable } from '@angular/core';
import { Catalogue, Article } from '../../Models';
import { Router, ActivatedRoute, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CatalogueService } from '../catalogue.service';
import { MatDialog } from '@angular/material/dialog';
import { DeleteArticleComponent } from './delete-article/delete-article.component';
import { EditArticleComponent } from './edit-article/edit-article.component';
import { AddArticleComponent } from './add-article/add-article.component';
import { SessionService } from 'src/app/auth/session.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  // id: number;
  o: Catalogue = new Catalogue();
  sub: any;
  constructor(private route: ActivatedRoute, private serviceData: CatalogueService
    , public dialog: MatDialog, public session: SessionService) {

  }

  ngOnInit(): void {
    this.getObjectFromRouteResolver();
  }

  getObjectFromRouteResolver() {
    this.route.data.subscribe(
      r => {
        this.o = r['mydata'];
        console.log(r);
      }, e => {
        console.log(e);
      }
    );
  }

  getCatalogue(id: number) {
    this.serviceData.get(id).subscribe((r: Catalogue) => {
      this.o = r;
      console.log(r);
      // this.o.articles.forEach(e => {
      //   e.imageUrl = atob(e.imageUrl);
      // });
    },
      e => console.log(e));
  }

  openDialogForDelete(o: Catalogue): void {
    const dialogRef = this.dialog.open(DeleteArticleComponent, {
      width: '550px',
      data: { id: o.id, obj: 'catalogue' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined) {
        console.log('vous avez quittez le dialog');
      } else {
        this.getCatalogue(this.o.id);
      }
    });
  }

  openDialogForAddEdit(o: Article): void {
    const dialogRef = this.dialog.open(AddArticleComponent, {
      width: '550px',
      data: {  id: this.o.id, obj: o }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined) {
        console.log('vous avez quittez le dialog');
      } else {
        this.getCatalogue(this.o.id);
      }
    });
  }

}

@Injectable({
  providedIn: 'root'
})
export class MyResolve implements Resolve<Observable<any>> {

  constructor(public service: CatalogueService) { }

  public resolve(route: ActivatedRouteSnapshot) {
    console.log(route.paramMap.get('id'));
    return this.service.get(route.paramMap.get('id')) as Observable<any>;
  }

}
