import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TreeViewComponent } from "./shared/tree-view/tree-view.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TreeViewComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor() {
  }

}
