import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MetierService } from '../metier.service';
import { Metier } from '../../Models';
import { TableSharedComponent } from '../table-shared/table-shared.component';

@Component({
  selector: 'app-metier',
  templateUrl: './metier.component.html',
  styleUrls: ['./metier.component.scss']
})
export class MetierComponent implements OnInit {

  // type_navire_list: string[];
  myForm: FormGroup;
  o: Metier = new Metier();
  columnDefs = [
    { columnDef: 'id', headName: 'id' },
    { columnDef: 'nom', headName: 'Nom' },
    { columnDef: 'option', headName: 'Option'},
  ];

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'nom', 'option'];
  //
  @ViewChild(TableSharedComponent) tableShared: TableSharedComponent;
  //
  isEdit = false;
  //
  constructor(private fb: FormBuilder, public serviceData: MetierService) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      nom: this.o.nom,
    });
  }

  rebuildForm() {
    this.myForm.reset({
      id: this.o.id,
      nom: this.o.nom,
    });
  }

  submit(o: FormGroup) {
    console.log('submit = ', o.value);
    const obj = o.value as Metier;
    if (!this.isEdit) {
      this.post(obj);
    } else {
      this.put(obj);
    }
  }

  post(o: Metier) {
    this.serviceData.post(o)
      .subscribe(r => {
        this.tableShared.update.next(true);
        this.rebuildForm();
        }, e => {
          console.log(e);
      });
  }

  put(o: Metier) {
    this.serviceData.put(o)
      .subscribe(r => {
        this.tableShared.update.next(true);
        this.isEdit = false;
        this.rebuildForm();
        }, e => {
          console.log(e);
      });
  }

  // thi function will be called by child component
  edit(o: Metier) {
    this.o = o;
    this.isEdit = true;
    this.rebuildForm();
  }

}
