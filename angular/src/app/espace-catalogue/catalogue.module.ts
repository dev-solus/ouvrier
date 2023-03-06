import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatalogueRoutingModule } from './catalogue-routing.module';
import { DeleteComponent } from './delete/delete.component';
import { MatModule } from '../mat.module';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';
import { CataloguesSharedComponent } from './catalogues-shared/catalogues-shared.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UtilsModule } from '../utils/utils.module';
import { DetailComponent } from './detail-article/detail.component';
import { EditArticleComponent } from './detail-article/edit-article/edit-article.component';
import { DeleteArticleComponent } from './detail-article/delete-article/delete-article.component';
import { AddArticleComponent } from './detail-article/add-article/add-article.component';
import { SharedModule } from '../espace-shared/shared.module';
import { AllComponent } from './all/all.component';

@NgModule({
    imports: [
        CommonModule,
        CatalogueRoutingModule,
        MatModule,
        FormsModule,
        ReactiveFormsModule,
        UtilsModule,
        SharedModule,
    ],
    declarations: [
        AddComponent,
        EditComponent,
        DetailComponent,
        DeleteComponent,
        ListComponent,
        CataloguesSharedComponent,
        EditArticleComponent,
        DeleteArticleComponent,
        AddArticleComponent,
        AllComponent,
    ]
})
export class CatalogueModule { }
