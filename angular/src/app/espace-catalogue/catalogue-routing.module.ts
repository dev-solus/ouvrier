import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditComponent } from './edit/edit.component';
import { EditResolve } from './edit/edit-resolve';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { DetailComponent, MyResolve } from './detail-article/detail.component';
import { AllComponent } from './all/all.component';

const routes: Routes = [
  { path: 'all'/*'app-list-catalogue'*/, component: AllComponent },
  { path: 'detail/:id', component: DetailComponent, resolve: { mydata: MyResolve }},
  { path: 'list/:id', component: ListComponent},
  { path: 'add', component: AddComponent},
  { path: 'edit/:id', component: EditComponent , resolve: {catalogue: EditResolve}},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogueRoutingModule { }
