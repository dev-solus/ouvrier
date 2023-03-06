import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Catalogue, User } from '../../Models';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { DeleteComponent } from '../delete/delete.component';
import { SessionService } from '../../auth/session.service';
import { CatalogueService } from '../catalogue.service';


@Component({
  selector: 'app-catalogues-shared',
  templateUrl: './catalogues-shared.component.html',
  styleUrls: ['./catalogues-shared.component.scss']
})
export class CataloguesSharedComponent implements OnInit {
  catalogues: Catalogue[] = [];
  // idToDelete: number;
  // we need this id for nowing with catalogues to bgings for him
  @Input() idUser = 0;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  resultsLength = 0;
  constructor(private service: CatalogueService
    , private route: Router, public dialog: MatDialog, private session: SessionService) {
  }

  ngOnInit() {
    this.getList();
    this.setPagination();
  }

  getList(startIndex = 0, pageSize = 6) {
    this.service.getList(this.idUser, startIndex, pageSize)
      .subscribe(r => {
        console.log('my list ', r.list);
        this.catalogues = r.list;
        this.resultsLength = r.count;
      },
        e => console.log(e)
      );
  }

  public setPagination() {
    // this.paginator.pageIndex = 0;
    this.paginator.page.subscribe(info => {
      const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    // console.log(this.paginator.pageIndex , this.paginator.pageSize);
      this.getList(startIndex, this.paginator.pageSize);
    });
  }

  openDialog(o: Catalogue): void {
    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '550px',
      data: { id: o.id, obj: 'catalogue' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined) {
        console.log('vous avez quittez le dialog');
      } else {
        this.getList();
      }
    });
  }

}
