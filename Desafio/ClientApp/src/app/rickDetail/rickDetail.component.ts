import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import RickLocationService from '../services/RickLocationService';
import { TravelComponent } from '../travel/travel.component';


@Component({
  selector: 'app-rickDetail-component',
  templateUrl: './rickDetail.component.html',
  styleUrls: ['./rickDetail.component.css'],

})
export class rickDetailComponent {
  service: RickLocationService;
  rick: any;
  visible: boolean;


  constructor(private route: ActivatedRoute) {
    this.service = new RickLocationService();
    this.visible = false;
  }

  onTraveled() {
    this.visible = false;
  }

  viajar(): void {
    
    this.visible = true;
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
