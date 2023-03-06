import { Component, OnInit, ViewChild, AfterViewInit, EventEmitter, Input, Output } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { TableSharedDataSource } from './table-shared-datasource';
import { merge, BehaviorSubject, Observable, pipe } from 'rxjs';
import { tap, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { isNull } from 'util';

@Component({
  selector: 'app-ltable',
  templateUrl: './table-shared.component.html',
  styleUrls: ['./table-shared.component.css']
})
export class TableSharedComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  //
  dataSource: any[] = [];
  // call it for every update in dataSOurce
  public update: EventEmitter<any> = new EventEmitter();
  // class datasource that handle the data for table
  dataSourceHandler: TableSharedDataSource;
  // searchTerm$ = new BehaviorSubject<string>('');
  @Input() columnDefs = [];
  @Input() displayedColumns = [];
  // service for manager our action with backend or db
  @Input() serviceData: any;
  // send object to be edited to parent component
  @Output() eventToParent = new EventEmitter<any>();
  //
  constructor() {}

  ngOnInit() {
    console.log('ngOnInit');
    this.dataSourceHandler = new TableSharedDataSource(this.paginator, this.sort, this.serviceData, this.update);
    // data is subscribed now , every event happen the will change and ofcource the datasource for table
    this.dataSourceHandler.methode()
      .subscribe(data => {
        // console.log('my data lolololo = ', data);
        this.dataSource = data;
      });
  }

  applyFilter(terms: string) {
    // console.log(terms.trim().toLowerCase());
    // const obs: Observable<string> =
    // (this.serviceData.search(terms) as Observable<any>).pipe(
    //   debounceTime(400),
    //   distinctUntilChanged(),
    //   map(data => {
    //     console.log(data[0]);
    //     return data[0];
    //   })
    // ).subscribe(data => this.dataSource = data);
    this.dataSourceHandler.methode()
      .subscribe(data => {
        // console.log('my data = ', data);
        this.dataSource = data;
      });
    // this.serviceData.search(terms)
    //   .subscribe(data => {
    //     // console.log(data);
    //     this.dataSource = data[0];
    //   });
    // return obs;
  }

  // post() {
  //   this.update.next(true);
  //   // return open;
  // }
  // send objet to parent class to deal with it
  put(o: any) {
    this.eventToParent.next(o);
  }
  // delete directly from this class
  delete(o: any) {
    console.log(o);
    this.serviceData.delete(o)
      .subscribe(r => {
        this.update.next(true);
      }, e => alert(e));
  }

}
