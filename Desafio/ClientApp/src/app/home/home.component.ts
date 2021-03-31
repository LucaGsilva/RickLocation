import { Component } from '@angular/core';
import RickLocationService from '../services/RickLocationService';
import { PageEvent } from '@angular/material/paginator';
import Paginator from '../paginator';
import { MatPaginatorIntl } from '@angular/material';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  service: RickLocationService;
  dimension: string = "";
  event: PageEvent;
  paginator: Paginator;



  constructor(private properties: MatPaginatorIntl) {
    this.service = new RickLocationService();
    this.paginator = new Paginator();
    this.paginator.pageSize = 10;
    properties.itemsPerPageLabel = "Itens por página";
  }



  update() {
    this.paginator.update();
  }

  pageChangeEvent(event: PageEvent) {
    this.paginator.paginate(event);
  }


  save() {
    this.service.createRick({ dimension: this.dimension }).then(
      (res) => {
        if (res.data.code == 200) {
          this.paginator.source.push(res.data.data);
          this.update();
          this.dimension = "";
        } else {
          alert(res.data.messages);
        }
      }
    );
  }

  ngOnInit(): void {
    console.log(this.properties)
    this.service.getRicks().then(
      (res) => {
        if (res.data.code == 200) {
          this.paginator.source = res.data.data;
          this.paginator.update();
        } else {
          alert(res.data.messages);
        }

      }
    ).catch(
      (res) => { alert("Falha ao Obter as Dimensões") }
    )
  }
}
