/**
 * Module ANgular
 */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { MatModule } from './mat.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppRoutes, AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
//
import { NavComponent } from './nav/nav.component';

import { LoaderService } from './loader/loader.service';
import { LoaderInterceptor } from './loader/loader-interceptor';
import { LoaderComponent } from './loader/loader.component';
//
import { SharedModule } from './espace-shared/shared.module';
import { AdminModule } from './espace-admin/admin.module';
import { CatalogueModule } from './espace-catalogue/catalogue.module';
import { AuthModule } from './auth/auth.module';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UtilsModule } from './utils/utils.module';
import { EditAboutComponent } from './home/edit-about/edit-about.component';
import { EditContactComponent } from './home/edit-contact/edit-contact.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { ScrollingModule } from '@angular/cdk/scrolling';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoaderComponent,
    HomeComponent,
    EditAboutComponent,
    EditContactComponent,
    // MapComponent,
  ],
  imports: [
    AngularEditorModule ,
    UtilsModule,
    ScrollingModule,
    //
    BrowserAnimationsModule,
    MatModule,
    // FlexLayoutModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
    // RouterModule.forRoot(AppRoutes),
  ],
  providers: [
    LoaderService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
