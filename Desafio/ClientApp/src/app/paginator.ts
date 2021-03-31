import { PageEvent } from '@angular/material/paginator';

export default class Paginator {

  length: number;
  pageSize: number;
  pageSizeOptions: number[] = [5, 10, 20, 50, 100];
  index: number;
  source: [];
  page: [];

  constructor() {
    this.source = [];
    this.page = [];
    this.length = this.source.length;
    this.index = 0;
    this.pageSize = 5;
   
  }

  paginate(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.index = event.pageIndex;
    this.update();

  }

  update() {
    var start = (this.pageSize * this.index);
    var end = start + this.pageSize;
    this.page = [];

    for (var i = start; i < end && i < this.source.length; i++) {

      this.page.push(this.source[i]);
    }

  }

  pageCount() {
    return Math.ceil(this.source.length / this.pageSize);
  }


}
