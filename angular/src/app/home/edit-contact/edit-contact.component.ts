import { Component, OnInit } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { HomeService } from '../home.service';
import { BehaviorSubject } from 'rxjs';
import { UntypedFormBuilder, Validators, UntypedFormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.scss']
})
export class EditContactComponent implements OnInit {
  name = 'Angular 6';
  htmlContent = '';
  o = new Contact();
  public myForm: UntypedFormGroup;
  config: AngularEditorConfig = this._getConfig;

  fixedSizeData = Array(10000).fill(30);
  observableData = new BehaviorSubject<number[]>([]);

  states = [
    { name: 'Alabama', capital: 'Montgomery' },
    { name: 'Alaska', capital: 'Juneau' },
    { name: 'Arizona', capital: 'Phoenix' },
    { name: 'Arkansas', capital: 'Little Rock' },
    { name: 'California', capital: 'Sacramento' }
  ];

  statesObservable = new BehaviorSubject(this.states);
  file: File;
  isImageUploaded: boolean;

  constructor(private fb: UntypedFormBuilder, private service: HomeService) { }

  ngOnInit(): void {
    this.createForm();
    this.getFromApi();
  }

  createForm() {
    this.myForm = this.fb.group({
      // user add
      nom: [this.o.nom, [Validators.minLength(2)]],
      prenom: [this.o.prenom],
      discriptionHTML: [this.o.discriptionHTML],
      imageUrl: [this.o.imageUrl],
    });
  }

  sortBy(prop: 'name' | 'capital') {
    this.statesObservable.next(this.states.map(s => ({ ...s })).sort((a, b) => {
      const aProp = a[prop], bProp = b[prop];
      if (aProp < bProp) {
        return -1;
      } else if (aProp > bProp) {
        return 1;
      }
      return 0;
    }));
  }

  getFromApi() {
    // this.service.get().subscribe(
    //   r => {
    //     console.log(r);
    //     this.htmlContent = r.aboutHTML;
    //   },
    //   e => console.log(e)
    // );
  }

  submit(myForm: UntypedFormGroup) {
    const obj: Contact = myForm.value;
    console.log(obj);
    // if (this.htmlContent) {
    //   this.serviceData.post(new Contact()).subscribe(
    //     r => {
    //       console.log(r);
    //     },
    //     e => console.log(e)
    //   );
    // }
  }

  edit(o) {
    console.log(o);
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

        },
        e => console.log(e)
      );
    }
  }


  get _getConfig() {
    return {
      editable: true,
      spellcheck: true,
      height: '15rem',
      minHeight: '5rem',
      placeholder: 'Discription ...',
      translate: 'no',
      uploadUrl: 'me',
      customClasses: [
        {
          name: 'quote',
          class: 'quote',
        },
        {
          name: 'redText',
          class: 'redText'
        },
        {
          name: 'titleText',
          class: 'titleText',
          tag: 'h1',
        },
      ]
    };
  }

}


export class Contact {
  nom = '';
  prenom = '';
  discriptionHTML = '';
  imageUrl = '';


  constructor() {
  }
}
