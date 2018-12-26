import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoaderService } from './loader.service';

@Injectable({
  providedIn: 'root'
})
export class LoaderInterceptor implements HttpInterceptor {
  private requests: HttpRequest<any>[] = [];
  public p: Observable<any>;
  i = 0;

  constructor(private loaderService: LoaderService) {
  }

  removeRequest(req: HttpRequest<any>) {
    // console.log('this.requests.length = ', this.requests.length);
    const i = this.requests.indexOf(req);
    if (i >= 0) {
      this.requests.splice(i, 1);
    }

    // console.log(i, this.requests.length);
    // this.p = this.requests.length;
    // this.loaderService.progress = this.requests.length;
    // console.log('progress = ', this.loaderService.progress);
    //
    this.loaderService.isLoading.next(this.requests.length > 0);
    //
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.requests.push(req);
    //
    this.loaderService.isLoading.next(true);
    //
    return Observable.create(observer => {
      const subscription = next.handle(req)
        .subscribe(
          event => {
            if (event instanceof HttpResponse) {

              // this.loaderService.progress = this.i++;
              // console.log('progress = ', this.loaderService.progress, this.i);
              this.removeRequest(req);
              observer.next(event);
              // console.log('>>>>>>>>>>>>>>', req.length);
            }
          },
          err => {
            this.removeRequest(req);
            observer.error(err);
          },
          () => {
            this.removeRequest(req);
            observer.complete();
          }
        );
      // teardown logic in case of cancelled requests
      return () => {
        this.removeRequest(req);
        subscription.unsubscribe();
      };
    });
  }
}
