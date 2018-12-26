import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { CompteComponent } from './compte/compte.component';
import { SignupComponent } from './signup/signup.component';
import { SigninComponent } from './signin/signin.component';
import { MatModule } from '../mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MapModule } from '../map/map.module';
import { UtilsModule } from '../utils/utils.module';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    MapModule,
    UtilsModule,
  ],
  declarations: [
    CompteComponent,
    SignupComponent,
    SigninComponent,
  ]
})
export class AuthModule { }
