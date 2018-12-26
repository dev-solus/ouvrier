import { Component, OnInit } from '@angular/core';
import { LoaderService } from './loader.service';
import { LoaderInterceptor } from './loader-interceptor';

@Component({
  selector: 'app-loader',
  template: `<p *ngIf="loader.isLoading | async">
              <mat-progress-bar mode="indeterminate" color="warn" style="height: 3px;"></mat-progress-bar>
            </p>`
})
export class LoaderComponent implements OnInit {
  constructor(public loader: LoaderService) {
   }

  ngOnInit() {
  }

}
