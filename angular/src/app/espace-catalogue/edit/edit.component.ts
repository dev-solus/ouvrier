import { OnInit, Component, OnDestroy } from '@angular/core';
import { Catalogue } from '../../Models';
import { Router, ActivatedRoute } from '@angular/router';
import { CatalogueService } from '../catalogue.service';


@Component({
    template: `<app-add [o]="o" (eventToParent)="put($event)"></app-add>`,
})

export class EditComponent implements OnInit, OnDestroy {

    o: Catalogue = new Catalogue();
    sub: any;
    id: number;
    constructor( private route: Router,
        private serviceData: CatalogueService, private routeA: ActivatedRoute) {

        this.sub = this.routeA.data.subscribe(data => {
            this.o = data['catalogue'];
            // this.o.articles.forEach(e => {
            //     e.imageUrl = atob(e.imageUrl);
            // });
        });
    }

    ngOnInit(): void {
        // this.sub = this.routeA.params.subscribe(params => {
        //     this.getCatalogue(params['id']);
        // });
    }

    // getCatalogue(id: number) {
    //     this.serviceData.get(id).subscribe((r: Catalogue) => {
    //         console.log(r);
    //         this.o = r;
    //     },
    //     e => console.log(e));
    // }


    put(o: Catalogue) {
        this.serviceData.put(o)
            .subscribe(r => {
                this.route.navigate(['']);
            }, e => {
                console.log(e);
            });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}

