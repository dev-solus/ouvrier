import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DeleteArticleComponent } from '../delete-article/delete-article.component';
import { ArticleService } from '../../article.service';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { Article } from 'src/app/Models';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-article',
  templateUrl: './add-article.component.html',
  styleUrls: ['./add-article.component.scss']
})
export class AddArticleComponent implements OnInit {
  myForm: UntypedFormGroup;
  // idCatalogue: number;
  o: Article = new Article;
  file: File;
  isImageUploaded = false;

  constructor(public dialogRef: MatDialogRef<DeleteArticleComponent>, private fb: UntypedFormBuilder
    , @Inject(MAT_DIALOG_DATA) public data: DataDialog, private service: ArticleService) {

  }

  ngOnInit() {
    console.log(this.data);
    this.o.idCatalogue = this.data.id;
    if (this.data.obj !== null) {
      this.o = this.data.obj;
      console.log('>>>>>>>>>>');
    }
    this.createForm();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      description: [this.o.description, Validators.required],
      idCatalogue: this.o.idCatalogue,
      imageUrl: this.o.imageUrl,
    });
  }

  submit(o: UntypedFormGroup) {
    console.log('submit = ', o.value);
    const obj = o.value as Article;
    if (this.o.id === 0) {
      if (this.file) {
        obj.imageUrl = 'Catalogues/' + this.file.name;
      }
      this.post(obj);
    } else {
      this.put(obj);
    }
  }

  post(o) {
    console.log('----------');
    console.log(o);
    this.service.post(o)
      .subscribe(r => {
        if (this.file) {
          this.postFile(this.file.name);
        }
        this.dialogRef.close('ok');
      }, e => {
        console.log(e);
      });
  }

  put(o: Article) {
    const backSlash = o.imageUrl.indexOf('/');
    let fileName = o.imageUrl.substring(backSlash + 1);
    if (fileName === '') {
      fileName = this.file.name;
      o.imageUrl = 'Catalogues/' + fileName;
    }
    this.service.put(o)
      .subscribe(r => {
        this.postFile(fileName);
      }, e => {
        console.log(e);
      });
  }

  getFileFromImgUpload(f: File) {
    this.file = f;
    this.isImageUploaded = true;
  }

  postFile(fileName) {
    if (this.file) {
      // console.log(fileName);
      const formData = new FormData();
      formData.append('file', this.file, fileName);

      // console.log(formData.get('file'));
      //
      this.service.postFile(formData).subscribe(
        res => {
          this.dialogRef.close('ok');
        },
        e => console.log(e)
      );
    }
    this.dialogRef.close('ok');
  }
}

interface DataDialog {
  id: number;
  obj: Article;
}
