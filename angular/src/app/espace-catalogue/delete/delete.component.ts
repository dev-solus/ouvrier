import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CatalogueService } from '../catalogue.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss']
})
export class DeleteComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DataDialog, private service: CatalogueService) {}

  ngOnInit() {
    console.log(this.data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public delete() {
    this.service.delete(this.data.id).subscribe(r => {
      console.log(r);
      this.dialogRef.close('ok');
    },
      e => {
        console.log(e);
        this.dialogRef.close();
      }
    );
  }

}

interface DataDialog {
  id: number;
  obj: string;
}
