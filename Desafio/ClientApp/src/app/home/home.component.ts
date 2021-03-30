import { Component } from '@angular/core';
import RickLocationService from '../services/RickLocationService';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  service: RickLocationService;
  dimension: string = "";


  constructor() {
    this.service = new RickLocationService();
  }

  ricks = [];

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
        } else {
          alert(res.data.messages);
        }

      }
    ).catch(
      (res) => { alert("Falha ao Obter as Dimensões") }
    )
  }
}
