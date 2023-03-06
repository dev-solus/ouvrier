import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, UntypedFormControl, Validators } from '@angular/forms';
import { SearchService } from './search.service';
import { Metier, Ville, Quartier, User, Location } from '../../Models';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  myForm: UntypedFormGroup;
  o: DataSearch;
  metiers: Metier[] = [];
  villes: Ville[] = [];
  quartiers: Quartier[] = [];
  //
  users: User[] = [];
  locations: Location[] = [];
  //
  styleBtn = 'bg-light';
  idUserColorIndicateur = 0;
  constructor(private fb: UntypedFormBuilder, public service: SearchService
    , private route: Router) {
  }

  ngOnInit() {
    this.createForm();
    this.service.getMetiers().subscribe(r => this.metiers = r);
    this.service.getVilles().subscribe(r => this.villes = r);
  }

  createForm() {
    this.myForm = this.fb.group({
      idVille: ['', Validators.required],
      idQuartier: [{ value: 0, disabled: true }, /* Validators.required*/],
      idMetier: [0],
    });
  }

  submit(o: UntypedFormGroup) {

    if (o.value.idQuartier === '' || o.value.idQuartier === '-1') {
      o.value.idQuartier = 0;
    }
    console.log('submit = ', o.value);

    this.service.get(o.value)
      .subscribe((r) => {
        // this.myForm.setValue(this.o);
        this.users = r;
        console.log(r);
        this.users.map(user => {
          const location = user.location;
          location.users = [];
          location.users.push(user);
          this.locations.push(user.location);
        });
      }, e => {
        console.log(e);
      });
  }

  // when the user change ville thelist of quatierwill initialzed
  get quartier(): UntypedFormControl {
    return this.myForm.get('idQuartier') as UntypedFormControl;
  }

  villeChange(idVille: number) {
    this.service.getQuartiers(idVille).subscribe(r => this.quartiers = r);
    this.quartier.enable();
  }

  setUser(o: User) {
    this.idUserColorIndicateur = o.id;
  }

  public ouvrier(o: User) {
    // this.data.user = o;
    // this.idUser = o.idUser;
    this.route.navigate(['ouvrier', o.id]);
  }

}

export interface DataSearch {
  idVille: number;
  idQuartier: number;
  idMetier: number;
}
