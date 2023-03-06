import { Component, OnInit, Input, AfterViewInit, OnDestroy, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { CatalogueService } from '../catalogue.service';
import { Catalogue, Article } from '../../Models';
import { SessionService } from '../../auth/session.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { DeleteComponent } from '../delete/delete.component';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit, OnDestroy {
  @Input() o: Catalogue = new Catalogue();
  a: Article = new Article();
  btnAddArticleActivated = false;
  public myForm: FormGroup;
  @Output() eventToParent = new EventEmitter<any>();
  files: File[] = [];

  constructor(public dialog: MatDialog, private session: SessionService, private fb: FormBuilder
    , private catalogueService: CatalogueService, private router: Router) {
    this.createForm();
  }

  ngOnInit() {
    console.log('this.o = ', this.o);
    // if id !== 0 its means that we goin to update object
    if (this.o.id !== 0) {
      // this.myForm.setValue(this.o);
      this.resetForm();
      this.articles.removeAt(0);
      this.o.articles.forEach(e => {
        // show image for edit in ui
        this.articles.push(this.fb.group(e));
      });
    }
  }

  // reset input
  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      nom: [this.o.nom, Validators.required],
      idUser: [this.session.userID()],
      articles: this.fb.array([]),
      // article: this.fb.array([this.fb.group(this.a)]),
    });
    this.articles.push(this.formGroupeArticle());
  }

  resetForm() {
    this.myForm.reset({
      id: this.o.id,
      nom: this.o.nom,
      idUser: this.session.userID(),
      // article: this.fb.array(this.o.article),
    });
  }

  get articles(): FormArray {
    return this.myForm.get('articles') as FormArray;
  }

  formGroupeArticle(): FormGroup {
    return this.fb.group({
      id: 0,
      description: [this.a.description, Validators.required],
      imageUrl: [null] ,
    });
  }

  addArticle() {
    (<FormArray>this.myForm.get('articles')).push(this.formGroupeArticle());
    this.btnAddArticleActivated = false;
  }


  onSubmit(myForm: FormGroup) {
    const obj: Catalogue = myForm.value;

    obj.articles.forEach((art, i) => {
        art.imageUrl = 'Catalogues/' + this.files[i].name;
    });
    if (this.o.id === 0) {
      this.post(obj);
    } else {
      this.put(obj);
    }
  }

  post(obj: Catalogue) {
    this.catalogueService.post(obj)
      .subscribe(
        r => {
          this.postFile().subscribe(
            res => {
              this.router.navigate(['/catalogues/all']);
            },
            e => console.log(e)
          );
        },
        e => {
          console.log(e);
        }
      );
  }

  put(obj: Catalogue) {
    this.eventToParent.next(obj);
  }

  getFileFromImgUpload(f: File) {
    this.files.push(f);
    // const l = this.myForm.get('articles').value as Article[];
    this.btnAddArticleActivated = true;
  }

  postFile() {
    const formData = new FormData();
    this.files.forEach((file, i) => {
      // if (file) {
        formData.append(`file${i}`, file, file.name);
      // }
    });

    //
    return this.catalogueService.postFile(formData);
  }
  //
  deleteArticle(i: number) {
    if (this.articles.length > 1) {
      this.files.splice(i, 1);
      this.articles.removeAt(i);
    }

    const articles: Article[] = this.articles.value;

    // console.log('------------');
    // console.log(articles.length);
    // console.log(this.files.length);
      if (articles.length !== this.files.length) {
        this.btnAddArticleActivated = false;
      }

  }

  get formValid() {
    // console.log(!this.myForm.valid && this.btnAddArticleActivated);
    return this.myForm.invalid && !this.btnAddArticleActivated || !this.btnAddArticleActivated || this.myForm.invalid;
  }

  ngOnDestroy() {
    // this.images = null;
  }
}
