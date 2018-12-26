import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UtilsRoutingModule } from './utils-routing.module';
import { ImgUploadComponent } from './img-upload/img-upload.component';
import { TestComponent } from './test/test.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatModule } from '../mat.module';
import { ImgDisplayComponent } from './img-display/img-display.component';

@NgModule({
  imports: [
    CommonModule,
    UtilsRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatModule,
  ],
  declarations: [
    ImgUploadComponent,
    TestComponent,
    ImgDisplayComponent,
  ],
  exports: [
    ImgUploadComponent,
    ImgDisplayComponent,
  ],
})
export class UtilsModule { }
