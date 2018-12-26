import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppPreloadingStrategy } from './preloader-module.service';
import { EditAboutComponent } from './home/edit-about/edit-about.component';
import { EditContactComponent } from './home/edit-contact/edit-contact.component';

export const AppRoutes: Routes = [
  // { path: '**', redirectTo: '' },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent},
  { path: 'edit-about', component: EditAboutComponent},
  { path: 'edit-contact', component: EditContactComponent},
  { path: 'catalogues', loadChildren: './espace-catalogue/catalogue.module#CatalogueModule', data: { preload: true, delay: false }  },
  { path: 'auth', loadChildren: './auth/auth.module#AuthModule', data: { preload: true, delay: true }   },
  { path: 'admin', loadChildren: './espace-admin/admin.module#AdminModule', data: { preload: true, delay: true }   },
  { path: 'shared', loadChildren: './espace-shared/shared.module#SharedModule' , data: { preload: true, delay: true }  },
  // { path: 'image', loadChildren: './utils/utils.module#UtilsModule'  },
  // { path: '', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(AppRoutes, {
    // enableTracing: true, // <-- debugging purposes only
    preloadingStrategy: AppPreloadingStrategy // PreloadAllModules
  })],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
