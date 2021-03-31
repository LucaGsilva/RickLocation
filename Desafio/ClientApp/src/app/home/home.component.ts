import { Component, ViewChild } from '@angular/core';
import RickLocationService from '../services/RickLocationService';
import { PageEvent, MatPaginatorIntl } from '@angular/material/paginator';
import Paginator from '../paginator';
import { read } from 'fs';


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


  constructor() {
    this.service = new RickLocationService();
    this.paginator = new Paginator();
    this.paginator.pageSize = 8;
  }

  

  update() {
    this.paginator.update();

    //if (this.event != null) {
    //  this.page = this.event.pageIndex;
    //  var start = (this.pageSize * this.event.pageIndex);
    //  var end = start + this.pageSize;

    //  this.previous = [];

    //  if (start == 0) {
    //    for (var i = 0; i < this.pageSize; i++) {
    //      this.previous.push(this.ricks[i]);
    //    }
    //  } else {
    //    for (var i = start; i < end; i++) {
    //      if (i <= (this.ricks.length - 1)) {
    //        this.previous.push(this.ricks[i]);
    //      }
    //    }
    //  }
    //}

  }

  pageChangeEvent(event: PageEvent) {
    this.paginator.paginate(event);
    //this.update();
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
