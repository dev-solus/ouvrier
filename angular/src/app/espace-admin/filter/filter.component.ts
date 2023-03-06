import { Component, OnInit, ViewChild, AfterViewInit, EventEmitter, Input, Output } from '@angular/core';
import { MatLegacyPaginator as MatPaginator } from '@angular/material/legacy-paginator';
import { MatSort } from '@angular/material/sort';
import { merge, BehaviorSubject, Observable, pipe } from 'rxjs';
import { tap, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { isNull } from 'util';
import { FilterDataSource } from './filter-datasource';
import { FilterService } from '../filter.service';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  //
  dataSource = [];
  dataSourceInitial = [];
  // call it for every update in dataSOurce
  public update: EventEmitter<any> = new EventEmitter();
  // class datasource that handle the data for table
  dataSourceHandler: FilterDataSource;
  columnDefs = [
    { columnDef: 'nom', headName: 'nom' },
    { columnDef: 'matricule', headName: 'Matricule' },
    { columnDef: 'type', headName: 'type' },
    { columnDef: 'dateConstat', headName: 'Date Constat' },
    { columnDef: 'verbalisateur', headName: 'Verbalisateur' },
    { columnDef: 'nature', headName: 'Nature' },
    { columnDef: 'lieu', headName: 'Lieu' },
    { columnDef: 'amende', headName: 'Amende' },
    { columnDef: 'suite', headName: 'Suite' },
    { columnDef: 'annee', headName: 'annee' },
  ];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    'nom', 'matricule', 'type', 'nature', 'verbalisateur', 'dateConstat'
    , 'lieu', 'amende', 'suite', 'annee'
  ];
  constructor(private serviceData: FilterService) { }

  ngOnInit() {
    console.log('ngOnInit');
    this.dataSourceHandler = new FilterDataSource(this.paginator, this.sort, this.serviceData);
    // data is subscribed now , every event happen the will change and ofcource the datasource for table
    this.dataSourceHandler.methode('')
      .subscribe(data => {
        this.dataSource = this.dataSourceInitial = data;
        this.footer();
        console.log('my data = ', this.dataSource);
      });
  }

  /** Gets the total cost of all transactions. */
  getTotalCost() {
    const tot: number = this.dataSource.map(t => t.amende).reduce((acc, value) => acc + value, 0);
    const year: number = this.dataSource.map(t => t.annee)[0];
    const obj: any = { amende: tot, annee: year };
    // this.dataSource.push(obj);
    return { tot, year };
  }

  initList(terms: string) {
    if (terms === '') {
      this.dataSource = this.dataSourceInitial;
    }
  }

  footer() {
    const tot: number = this.dataSource.map(t => t.amende).reduce((acc, value) => acc + value, 0);
    const year: number = this.dataSource.map(t => t.annee)[0];
    const obj: any = {lieu: 'Total =', amende: tot, suite: 'Annee =' , annee: year };
    this.dataSource.push(obj);
  }

  search(terms: string) {
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
    this.dataSourceHandler.methode(terms)
      .subscribe(data => {
        // console.log('my data = ', data);
        this.dataSource = data;
        this.footer();
      });
    // this.serviceData.search(terms)
    //   .subscribe(data => {
    //     // console.log(data);
    //     this.dataSource = data[0];
    //   });
    // return obs;
  }

}
