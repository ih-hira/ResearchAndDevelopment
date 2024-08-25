import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import OrgChart from "@balkangraph/orgchart.js";
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'bd-party-tree';
  data: any[] = [];
  private http = inject(HttpClient);
  /**
   *
   */
  constructor() {
    this.getData().subscribe(
      (response) => {
        this.data = response;
        this.updateTree();
        console.log(this.data);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }
  updateTree() {
    const tree = document.getElementById('tree');
    if (tree) {
      var chart = new OrgChart(tree, {
        template: 'diva',
        orientation: OrgChart.orientation.left,
        layout: OrgChart.mixed,
        collapse: {
          level: 1,
          allChildren: true
        },
        nodeBinding: {
          field_0: "title",
          field_1: "name",
          img_0: "icon"
        },
      });
      
      // chart.load([
      //   { id: 1, name: "বাংলাদেশ নির্বাচন কমিশন", title: "নি.ক.", img: "https://www.ecs.gov.bd/front/assets/images/logo.png" },
      //   { id: 2, pid: 1, name: "লিবারেল ডেমোক্রেটিক পার্টি", title: "এলডিপি", img: "https://www.ecs.gov.bd/bec/public/photos/1/Chhata.PNG" }
      // ]);
      chart.load(this.data);

    }
  }
  getData(): Observable<any> {
    return this.http.get<any>('http://127.0.0.1:5000/api/getPartyOverview'); // Replace with your API endpoint
  }
}
