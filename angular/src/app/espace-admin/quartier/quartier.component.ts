import { Component, OnInit, ViewChild } from '@angular/core';
import { MatLegacyDialog as MatDialog } from '@angular/material/legacy-dialog';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { TableSharedComponent } from '../table-shared/table-shared.component';
import { QuartierService } from '../quartier.service';
import { Quartier, Ville } from '../../Models';

@Component({
  selector: 'app-quartier',
  templateUrl: './quartier.component.html',
  styleUrls: ['./quartier.component.css']
})
export class QuartierComponent implements OnInit {
  myForm: UntypedFormGroup;
  o: Quartier = new Quartier();
  villes: Ville[] = [];
  columnDefs = [
    { columnDef: 'id', headName: 'id' },
    { columnDef: 'nom', headName: 'Nom' },
    { columnDef: 'ville', headName: 'Ville' },
    { columnDef: 'option', headName: 'Option'},
  ];

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'nom', 'ville', 'option'];
  //
  @ViewChild(TableSharedComponent) tableShared: TableSharedComponent;
  //
  isEdit = false;
  //
  constructor(public dialog: MatDialog, private fb: UntypedFormBuilder, public serviceData: QuartierService) { }

  ngOnInit() {
    // this.type_navire_list = this.storageService.getList();
    this.serviceData.getVilles().subscribe(r => this.villes = r);
    this.createForm();
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      nom: this.o.nom,
      idVille: [null, Validators.required]
    });
  }

  rebuildForm() {
    this.myForm.reset({
      id: this.o.id,
      nom: this.o.nom,
      idVille: null
    });
  }

  submit(o: UntypedFormGroup) {
    console.log('submit = ', o.value);
    const obj = o.value as Quartier;
    if (!this.isEdit) {
      this.post(obj);
      this.rebuildForm();
    } else {
      this.put(obj);
      this.rebuildForm();
    }
  }

  post(o: Quartier) {
    // observableOf(this.dataSource.data).
    this.serviceData.post(o)
      .subscribe(r => {
        this.tableShared.update.next(true);
        }, e => {
          console.log(e);
      });
    // console.log(this.storageService.updateTypeNavire(this.dataSource.data));
    // this.storageService.updateList(this.TABLE_KEY, this.dataSource.data);
  }

  put(o: Quartier) {
    this.serviceData.put(o)
      .subscribe(r => {
        this.tableShared.update.next(true);
        this.isEdit = false;
        }, e => {
          console.log(e);
      });
  }

  // thi function will be called by child component
  edit(o: Quartier) {
    // console.log('child to parent works', o);
    this.o = o;
    this.isEdit = true;
    this.rebuildForm();
    // this.editBool = true;
  }

  // openDialog(): void {
  //   const dialogRef = this.dialog.open(TypeNavireComponent, {
  //     width: '550px',
  //     // data: {name: this.name, animal: this.animal}
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     console.log('The dialog was closed');
  //     this.type_navire_list = this.storageService.getList('TABLE_TYPE_NAVIRE');
  //     // this.animal = result;
  //   });
  // }

}
