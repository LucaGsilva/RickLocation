import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import RickLocationService from '../services/RickLocationService';
import { TravelComponent } from '../travel/travel.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-rickDetail-component',
  templateUrl: './rickDetail.component.html',
  styleUrls: ['./rickDetail.component.css'],

})
export class rickDetailComponent {
  service: RickLocationService;
  rick: any;


  constructor(private route: ActivatedRoute, private dialog: MatDialog,
    public dialogRef: MatDialogRef<TravelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.service = new RickLocationService();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(TravelComponent, {
      width: '250px',
      data: this.rick
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.animal = result;
    });
  }


  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      const id = params['id'];
      this.service.getRick(id).then(
        (res) => {
          if (res.data.code == 200) {
            this.rick = res.data.data
          } else {
            alert(res.data.messages);
          }

        }
      ).catch(
        (res) => { alert("Falha ao Obter o Rick") }
      )
    })

  }
}
