import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedRoutingModule } from './shared-routing.module';
import { MatModule } from '../mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//
import { CommentComponent } from './comment/comment.component';
import { CountCommentComponent } from './comment/comment-count/comment-count.component';
import { FavorieComponent } from './favorie/favorie.component';
import { UpdateFavorieComponent } from './favorie/update-favorie/update-favorie.component';
import { LikeComponent } from './like/like.component';
import { OuvrierComponent } from './ouvrier/ouvrier.component';
import { SearchComponent } from './search/search.component';
import { MapModule } from '../map/map.module';
import { UtilsModule } from '../utils/utils.module';

@NgModule({
  imports: [
    MapModule,
    CommonModule,
    SharedRoutingModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    UtilsModule,
  ],
  declarations: [
    CommentComponent,
    CountCommentComponent,
    FavorieComponent,
    UpdateFavorieComponent,
    LikeComponent,
    OuvrierComponent,
    SearchComponent,
  ]
})
export class SharedModule { }
