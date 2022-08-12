import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'tm-tvmaze',
  template: `
    <div [innerHtml]="modelHtml"></div>
  `,
  styles: [
  ]
})
export class TvmazeComponent implements OnInit {

  @Input() modelHtml: string="";

  constructor() { }

  ngOnInit(): void {
  }

}
