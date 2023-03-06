import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms/src/directives/ng_form';
import { UntypedFormBuilder, UntypedFormGroup, Validators, FormArray, UntypedFormControl } from '@angular/forms';
import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { User, Location, Ville, Metier, Quartier } from '../../Models';
import { SessionService } from 'src/app/auth/session.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})

export class SignupComponent implements OnInit {
  @Input() id = 0;
  @Input() o: User = new User();
  // a: Location = new Location();
  public myForm: UntypedFormGroup;
  metiers: Metier[] = [];
  villes: Ville[] = [];
  quartiers: Quartier[] = [];
  // imgUser: string;
  imgUser = '../assets/user.png';
  idVille = -1;
  hide = true;
  file: File;
  imgName = '';
  constructor(private signupService: AuthService, private fb: UntypedFormBuilder
    , private router: Router, public session: SessionService) {
    this.createForm();
  }

  ngOnInit() {
    if (this.o.id !== 0) {
      this.compte();
    }

    this.signupService.getMetiers().subscribe(r => this.metiers = r);
    this.signupService.getVilles().subscribe(r => this.villes = r);
    this.myForm.get('idMetier').disable();
  }

  compte() {
    if (this.o.type === 'ouvrier') {
      this.myForm.get('idMetier').enable();
    }
    this.signupService.getQuartiers(0).subscribe(q => {
      this.quartiers = q;
      this.idVille = this.o.location.quartier.idVille;
      this.quartier.enable();
      this.myForm.setValue(this.o);
      this.myForm.get('password').setValidators(null);
      this.myForm.get('password').setValue('');
    });
  }
  // reset input
  createForm() {
    this.myForm = this.fb.group({
      // user add
      id: this.o.id,
      type: [this.o.type, [Validators.required]],
      role: this.o.role,
      idMetier: [this.o.idMetier, [Validators.required]],
      username: [this.o.username, [Validators.minLength(4)]],
      lastName: [this.o.lastName],
      dateNaissance: [this.o.dateNaissance],
      email: [this.o.email, [Validators.required, Validators.email]],
      password: [this.o.password, [Validators.minLength(6), Validators.required]],
      civilite: [this.o.civilite, [Validators.required]],
      tel: [this.o.tel, [Validators.required]],
      imageUrl: [this.o.imageUrl],
      idLocation: [this.o.idLocation],
      metier: '',
      // location add
      location: this.fb.group({
        id: [this.o.location.id],
        adresse: [this.o.location.adresse, [Validators.required]],
        lat: [this.o.location.lat, [Validators.required]],
        lng: [this.o.location.lng, [Validators.required]],
        draggble: [this.o.location.draggble],
        // quartier add
        idQuartier: [{ value: this.o.location.idQuartier, disabled: true }],
        quartier: '',
        users: ''
      }) // end location
    }); // end user
  }

  onSubmit(myForm: UntypedFormGroup) {
    const obj: User = myForm.value;
    console.log(obj);
    obj.role = this.defineRole(obj);
    obj.imageUrl = 'Users/' + this.imgName;
    if (obj.id === 0) {
      this.post(obj);
    } else {
      this.put(obj);
    }
  }

  post(obj: User) {
    // console.log(this.myForm.get('imageUrl').value);
    this.signupService.register(obj)
      .subscribe(
        (response: any) => {
          console.log(response);
          this.postFile().subscribe(
            r => {
              this.router.navigate(['auth/signin']);
            },
            e => console.log(e)
          );
        },
        error => {
          console.log(error);
        }
      );
  }

  defineRole(user: User): number {

    if (user.role && user.role !== 1 && user.role !== 2) {
      return user.role;
    }
    if (user.type === 'simple') {
      return 1;
    } else if (user.type === 'ouvrier') {
      return 2;
    }
  }

  put(obj: User) {
    this.signupService.put(obj)
      .subscribe(
        (response: any) => {
          console.log(response);
          this.session.doSignIn(response.token, response.user);
          this.postFile().subscribe(
            r => {
              this.router.navigate(['']);
            },
            e => console.log(e)
          );
        },
        error => {
          console.log(error);
        }
      );
  }

  getFileFromImgUpload(f: File) {
    this.file = f;
    // const dot: number = this.file.name.lastIndexOf('.');
    // const imgExtension = this.file.name.substring(dot);
    this.imgName = this.o.email + '.jpg';
  }

  postFile() {
    const formData = new FormData();
    formData.append('file', this.file, this.imgName);
    //
    return this.signupService.postFile(formData);
  }
  //
  get latitude() {
    return this.myForm.get('location').get('lat') as UntypedFormControl;
  }

  get longitude() {
    return this.myForm.get('location').get('lng') as UntypedFormControl;
  }

  setLocation(lat: number, lng: number) {
    this.latitude.setValue(Math.round(lat * 100) / 100);
    this.longitude.setValue(Math.round(lng * 100) / 100);
  }
  // thi function will be called by child component
  setPosition(o: any) {
    this.setLocation(o.lat, o.lng);
  }

  // when the user change ville thelist of quatierwill initialzed
  get quartier(): UntypedFormControl {
    return this.myForm.get('location').get('idQuartier') as UntypedFormControl;
  }

  villeChange(idVille: number) {
    console.log('idVille = ', idVille);
    this.signupService.getQuartiers(idVille).subscribe(r => this.quartiers = r);
    this.quartier.enable();
  }

  typeChange(o: any) {
    if (o === 'simple') {
      this.myForm.get('idMetier').disable();
    } else {
      this.myForm.get('idMetier').enable();
    }
  }
}

