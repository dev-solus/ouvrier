import { Component, OnInit, Inject } from '@angular/core';
import { MatLegacyDialogRef as MatDialogRef, MAT_LEGACY_DIALOG_DATA as MAT_DIALOG_DATA } from '@angular/material/legacy-dialog';
import { ArticleService } from '../../article.service';

@Component({
  selector: 'app-delete-article',
  templateUrl: './delete-article.component.html',
  styleUrls: ['./delete-article.component.scss']
})
export class DeleteArticleComponent implements OnInit {


  constructor(public dialogRef: MatDialogRef<DeleteArticleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DataDialog, private service: ArticleService) { }

  ngOnInit() {
    console.log(this.data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public delete() {
    this.service.delete(this.data.id).subscribe(
      r => {
        console.log(r);
        this.dialogRef.close('ok');
      },
      e => console.log(e)
    );
  }

}

interface DataDialog {
  id: number;
  obj: string;
}
