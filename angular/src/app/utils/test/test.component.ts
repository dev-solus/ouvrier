import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  myForm: UntypedFormGroup;
  o: Obj = new Obj();
  display: any = 'waiting ...';
  file: File;
  // this variable needed for this component children;
  imgUrl = 'users/m3alam.jpg';
  constructor(private fb: UntypedFormBuilder) { }

  ngOnInit() {
    this.myForm = this.fb.group({
      nom: this.o.nom,
      imgUrl: [null, [Validators.required]],
    });
  }

  getFileFromImgUpload(f: File) {
    this.file = f;
    console.log(this.file.name);
  }

  // getImgFromImgUpload(imgBase64: string) {
  //   this.imgUrl = imgBase64;
  //   // console.log(this.imgUrl);
  // }

  submit(e: UntypedFormGroup) {
    this.display = e.value;
  }

}

class Obj {
  nom = 'mourabit';
  imgUrl = '';
}
