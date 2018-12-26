import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OuvrierComponent } from './ouvrier/ouvrier.component';
import { FavorieComponent } from './favorie/favorie.component';
import { SearchComponent } from './search/search.component';
// import { CataloguesSharedComponent } from '../espace-catalogue/catalogues-shared/catalogues-shared.component';

const routes: Routes = [
  //  { path: 'list/:id', component: CataloguesSharedComponent},
   { path: 'ouvrier/:id', component: OuvrierComponent},
   { path: 'fav', component: FavorieComponent},
   { path: 'search', component: SearchComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharedRoutingModule { }
