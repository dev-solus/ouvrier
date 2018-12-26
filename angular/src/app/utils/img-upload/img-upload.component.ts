import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-img-upload',
  templateUrl: './img-upload.component.html',
  styleUrls: ['./img-upload.component.css']
})
export class ImgUploadComponent implements OnInit {
  @Input() imgUrl: any = '../../../assets/user.png';
  @Input() width = '600';
  @Input() height = '400';
  // colorInputFile = '';
  // @Output() file: File;
  // send object to be edited to parent component
  @Output() eventToParent = new EventEmitter<File>();
  fileName = '';
  constructor() { }

  ngOnInit() {
    this.imgUrl = environment.hubUrl + this.imgUrl;
    console.log('this.imgUrl');
    console.log(this.imgUrl);
  }

  openInput(o/*: HTMLInputElement*/) {
    o.click();
  }

  handleFileInput(files: FileList) {
    this.fileName = ' : ' + files.item(0).name;
    console.log(this.sizeFile(files.item(0).size));
    this.compress(files);
    // return;
    // this.eventToParent.next(files.item(0));

    // const reader = new FileReader();

    // reader.onload = (event: any) => {
    //   this.imgUrl = reader.result.toString();
    //   // this.colorInputFile = '';
    // };

    // reader.readAsDataURL(files.item(0));
  }

  imgError(img: any) {
    console.log('>>>>>>>>>>>>>>');
    img.src = '../../../assets/user.png';
  }

  compress(files: FileList) {
    const file = files.item(0);
    const width = 500;
    const height = 500;
    const fileName = file.name;
    const reader = new FileReader();

    reader.onload = (event) => {
      this.imgUrl = reader.result.toString();
      const img = new Image();
      img.src = reader.result.toString();
      img.onload = () => {
        const elem = document.createElement('canvas');
        elem.width = width;
        elem.height = height;
        const ctx = elem.getContext('2d');
        // img.width and img.height will give the original dimensions
        ctx.drawImage(img, 0, 0, width, height);
        ctx.canvas.toBlob((blob) => {
          const file2 = new File([blob], fileName, {
            type: 'image/jpeg',
            lastModified: Date.now()
          });
          this.eventToParent.next(file2);
          console.log(this.sizeFile(file2.size));
        }, 'image/jpeg', 0.95);
      },
        reader.onerror = error => console.log(error);
    };

    reader.readAsDataURL(file);
  }

  sizeFile(sizeByte) {
    if (sizeByte < 1000000) {
      return Math.floor(sizeByte / 1000) + 'KB';
    }
    return Math.floor(sizeByte / 1000000) + 'MB';
  }

}
