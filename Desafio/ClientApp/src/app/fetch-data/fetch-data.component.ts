import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public people: Peoples[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Peoples[]>(baseUrl + 'people').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }
}

interface Peoples {
  Id: number;
  Nome: string;
  Morty: string;
  Dimension: string;
}
