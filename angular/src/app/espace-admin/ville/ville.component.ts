import { Component, OnInit, ViewChild } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder } from '@angular/forms';
import { VilleService } from '../ville.service';
import { TableSharedComponent } from '../table-shared/table-shared.component';
import { Ville } from '../../Models';

@Component({
  selector: 'app-ville',
  templateUrl: './ville.component.html',
  styleUrls: ['./ville.component.scss']
})
export class VilleComponent implements OnInit {

  // type_navire_list: string[];
  myForm: UntypedFormGroup;
  o: Ville = new Ville();
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
  constructor(private fb: UntypedFormBuilder, public serviceData: VilleService) { }

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

  submit(o: UntypedFormGroup) {
    console.log('submit = ', o.value);
    const obj = o.value as Ville;
    if (!this.isEdit) {
      this.post(obj);
    } else {
      this.put(obj);
    }
  }

  post(o: Ville) {
    this.serviceData.post(o)
      .subscribe(r => {
        this.tableShared.update.next(true);
        this.rebuildForm();
        }, e => {
          console.log(e);
      });
  }

  put(o: Ville) {
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
  edit(o: Ville) {
    this.o = o;
    this.isEdit = true;
    this.rebuildForm();
  }

}
