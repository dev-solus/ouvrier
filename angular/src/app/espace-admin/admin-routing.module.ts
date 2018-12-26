import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MetierComponent } from './metier/metier.component';
import { QuartierComponent } from './quartier/quartier.component';
import { VilleComponent } from './ville/ville.component';

const routes: Routes = [
    //
    { path: 'metier', component: MetierComponent },
    { path: 'quartier', component: QuartierComponent },
    { path: 'ville', component: VilleComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
