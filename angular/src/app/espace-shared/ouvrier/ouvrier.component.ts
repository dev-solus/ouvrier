import { Component, OnInit, OnDestroy } from '@angular/core';
import { User } from '../../Models';
import { Router, ActivatedRoute } from '@angular/router';
import { OuvrierService } from './ouvrier.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-ouvrier',
  templateUrl: './ouvrier.component.html',
  styleUrls: ['./ouvrier.component.scss']
})
export class OuvrierComponent implements OnInit, OnDestroy {
  idUser = 0;
  o: Observable<User>;
  sub: any;
  id: number;
  constructor(private route: Router, private routeA: ActivatedRoute, private service: OuvrierService) {
    this.sub = this.routeA.params.subscribe(params => {
      // this.getData(params['id']);
      this.id = params['id'];
    });
  }

  ngOnInit() {
    this.o = this.service.get(this.id);
  }

  // getData() {
  //   this.service.get(this.id).subscribe(r => {
  //     console.log(r);
  //     this.o = r;
  //     this.o.imageUrl = atob(this.o.imageUrl);
  //   },
  //     e => console.log(e));
  // }

  public catalogue() {
    // this.data.user = o.idUserNavigation;
    // this.idUser = o.idUser;
    // this.route.navigate(['list', this.o.id]);
  }

  // image(img: string): string {
  //   return atob(img);
  // }

  setPosition(event: any) {

  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
