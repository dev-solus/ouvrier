import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map, tap, startWith, switchMap, catchError } from 'rxjs/operators';
import { Observable, of as observableOf, merge, BehaviorSubject } from 'rxjs';
import { Injectable, EventEmitter } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
export class FilterDataSource {
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  constructor(private paginator: MatPaginator, private sort: MatSort
    , private serviceData: any) {

  }

  methode(terms: string): Observable<any[]> {
    const dataMutations = [
      this.paginator.page,
      this.sort.sortChange,
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
          // console.log(this.serviceData.count());
          return this.serviceData.count();
        }),
        map(count => {
          // get length of data
          // console.log(count[0][0].count);
          this.resultsLength = count[0][0].count;
        }),
        switchMap(() => {
          const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
          return this.loadInitialData(this.sort.active, this.sort.direction, startIndex, this.paginator.pageSize, terms);
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          if (terms !== '') {
            this.resultsLength = data[0].length;
          }
          return data[0];
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
  loadInitialData(colToSort = '', orderBy = 'asc', startIndex = 0, pageSize = 10, term: string) {
    return this.serviceData.getAllWithFilter(colToSort, orderBy, startIndex, pageSize, term);
  }
  // this._todos.next(this._todos.getValue().push(newTodo));

}


