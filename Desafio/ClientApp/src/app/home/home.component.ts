import { Component } from '@angular/core';
import RickLocationService from '../services/RickLocationService';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  service: RickLocationService;
  dimension: string = "";
  len = 150;
  pageSizeOptions: number[];
  splicedData: any;
  requests: any;


  constructor() {
    this.service = new RickLocationService();
  }

  ricks = [];
  previous = [];

  pageChangeEvent(event) {
    console.log(this.previous);
  }


  save() {
    this.service.createRick({ dimension: this.dimension }).then(
      (res) => {
        if (res.data.code == 200) {
          this.ricks.push(res.data.data);
          this.dimension = "";
        } else {
          alert(res.data.messages);
        }
      }
    );
  }

  ngOnInit(): void {
    this.service.getRicks().then(
      (res) => {
        if (res.data.code == 200) {
          this.ricks = res.data.data
          this.previous = this.ricks;
          console.log(this.previous);
        } else {
          alert(res.data.messages);
        }

      }
    ).catch(
      (res) => { alert("Falha ao Obter as Dimensões") }
    )
  }
}
