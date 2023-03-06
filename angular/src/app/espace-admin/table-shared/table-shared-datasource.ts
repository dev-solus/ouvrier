import { DataSource } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { map, tap, startWith, switchMap, catchError } from 'rxjs/operators';
import { Observable, of as observableOf, merge, BehaviorSubject } from 'rxjs';
import { Injectable, EventEmitter } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
export class TableSharedDataSource {
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  constructor(private paginator: MatPaginator, private sort: MatSort
    , private serviceData: any, public update: EventEmitter<any>) {

  }

  methode(): Observable<any> {
    const dataMutations = [
      this.paginator.page,
      this.sort.sortChange,
      this.update
    ];
    // if sort changed set pageindex to zero
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    const obs = merge(...dataMutations)
      .pipe(
        startWith({}),
        switchMap((update) => {
          // if data is updated we init the page index to 0
          // need more operation here for sortable things
          if (update === true) {
            this.paginator.pageIndex = 0;
          }
          this.isLoadingResults = true;
          console.log('this.sort.active', this.sort.active);
          if (!this.paginator.pageSize) {
            this.paginator.pageSize = 5;
          }
          if (!this.sort.direction) {
            this.sort.direction = 'asc';
          }
          if (!this.sort.active) {
            this.sort.active = 'id';
          }
          // if (this.sort.active === 'option') {
          //   return;
          // }
          const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
          console.log(this.paginator.pageIndex , this.paginator.pageSize);
          return this.serviceData.getList(this.sort.active, this.sort.direction, startIndex, this.paginator.pageSize);
        }),
        map((r: Reponce) => {
          // get length of data
          console.log(r);
          this.resultsLength = r.count;
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          return r.list;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          // Catch if the API has reached its rate limit. Return empty data.
          this.isRateLimitReached = true;
          return observableOf([]);
        })
      );
    return obs;
  }

  // get data from api
  // loadInitialData(colToSort = '', orderBy = 'asc', startIndex = 0, pageSize = 10) {
  //   return this.serviceData.getAll(colToSort, orderBy, startIndex, pageSize);
  // }
  // this._todos.next(this._todos.getValue().push(newTodo));

}

interface Reponce {
  count: number;
  list: any[];
}


