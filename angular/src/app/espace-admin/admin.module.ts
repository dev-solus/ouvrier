import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { FilterComponent } from './filter/filter.component';
import { MetierComponent } from './metier/metier.component';
import { QuartierComponent } from './quartier/quartier.component';
import { TableSharedComponent } from './table-shared/table-shared.component';
import { VilleComponent } from './ville/ville.component';
import { MatModule } from '../mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    FilterComponent,
    MetierComponent,
    QuartierComponent,
    TableSharedComponent,
    VilleComponent,
  ]
})
export class AdminModule { }
