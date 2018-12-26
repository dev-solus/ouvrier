import { Injectable } from '@angular/core';
import { Observable, timer, of } from 'rxjs';
import { flatMap } from 'rxjs/operators';
import { Route, PreloadingStrategy } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AppPreloadingStrategy implements PreloadingStrategy {
  preload(route: Route, load: Function): Observable<any> {
    const loadRoute = (delay) => delay
      ? timer(3000).pipe(flatMap(_ => load()))
      : load();
    return route.data && route.data.preload
      ? loadRoute(route.data.delay)
      : of(null);
  }
}
