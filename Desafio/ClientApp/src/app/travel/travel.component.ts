import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import RickLocationService from '../services/RickLocationService';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-travel',
  templateUrl: './travel.component.html',
  styleUrls: ['./travel.component.css']
})
export class TravelComponent implements OnInit {
  service: RickLocationService;
  dimensions: any[];
  //rick: any;
  dimensionId: any;


  @Output()
  traveled = new EventEmitter();

  @Input()
  rick: any;

  constructor(private route: ActivatedRoute, private router: Router) {
    this.service = new RickLocationService();
  }

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {

      this.service.getRicks().then(
        (res) => {
          if (res.data.code == 200) {
            const ricks = res.data.data;
            this.dimensions = [];

            for (var i = 0; i < ricks.length; i++) {
              this.dimensions.push(ricks[i].dimension);
            }

          } else {
            alert(res.data.messages);
          }

        }
      ).catch(
        (res) => { alert("Falha ao Obter as Viagens") }
      )

    })


  }

  cancel() {
    this.traveled.emit();
  }

  async save() {

    this.service.createTravel({ rickId: this.rick.id, dimensionId: Number.parseInt(this.dimensionId) }).then(
      (res) => {
        if (res.data.code == 200) {
          this.traveled.emit();
        } else {
          alert(res.data.messages);
        }
      }
    ).catch(
      (res) => { alert("Falha ao registrar a Viagem") }
    );
  }

}
