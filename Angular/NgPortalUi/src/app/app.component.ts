import { Component, ElementRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public session:any;
  title = 'NgPortalUi';
  /**
   *
   */
  constructor(private elementRef: ElementRef) {
    this.session = JSON.parse(this.elementRef.nativeElement.getAttribute('session'));
    console.log(this.session);

  }
  onActivate(component:any) {
    // you have access to the component instance
    component.title=this.title;
  }
}
