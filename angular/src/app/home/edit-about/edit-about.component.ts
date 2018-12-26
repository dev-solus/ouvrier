import { Component, OnInit } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { HomeService } from '../home.service';



@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.scss']
})
export class EditAboutComponent implements OnInit {

  name = 'Angular 6';
  htmlContent = '';

  config: AngularEditorConfig = this._getConfig;

  constructor(private service: HomeService) { }

  ngOnInit(): void {
    this.getFromApi();
  }

  getFromApi() {
    this.service.get().subscribe(
      r => {
        console.log(r);
        this.htmlContent = r.aboutHTML;
      },
      e => console.log(e)
    );
  }

  submit() {
    if (this.htmlContent) {
      this.service.post(new About(this.htmlContent)).subscribe(
        r => {
          console.log(r);
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
      placeholder: 'Enter text here...',
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

export class About {

  aboutHTML: string;

  constructor(aboutHTML = 'Ecrire un text...') {
    this.aboutHTML = aboutHTML;
  }
}
