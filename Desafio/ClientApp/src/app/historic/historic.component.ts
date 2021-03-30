import { Component, OnInit } from '@angular/core';
import RickLocationService from '../services/RickLocationService';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-historic',
  templateUrl: './historic.component.html',
  styleUrls: ['./historic.component.css']
})
export class HistoricComponent implements OnInit {
  service: RickLocationService;
  id: any;
  rick: any;
    travels: any;

  constructor(private route: ActivatedRoute, private router: Router) {
    this.service = new RickLocationService();
  }

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.id = params['id'];

      this.service.getRick(this.id).then(
        (res) => {

          if (res.data.code == 200) {
            this.rick = res.data.data;
          } else {
            alert(res.data.messages);
          }

        }
      ).catch(
        (res) => { alert("Falha ao Obter o Historico") }
      )

      this.service.getTravels(this.id).then(
        (res) => {

          if (res.data.code == 200) {
            this.travels = res.data.data;
          } else {
            alert(res.data.messages);
          }

        }
      ).catch(
        (res) => { alert("Falha ao Obter o Historico") }
      )

    })

  }

}
