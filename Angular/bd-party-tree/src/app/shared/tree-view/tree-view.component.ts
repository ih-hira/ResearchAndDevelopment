
import { Component, inject } from '@angular/core';
import OrgChart from '@balkangraph/orgchart.js';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'tree-view',
  standalone: true,
  imports: [],
  providers:[ApiService],
  templateUrl: './tree-view.component.html',
  styleUrl: './tree-view.component.css'
})
export class TreeViewComponent {
  title = 'bd-party-tree';
  data: any[] = [];
  constructor(private apiService: ApiService) {
    apiService.getData().subscribe(
      (response: any[]) => {
        this.data = response;
        this.updateTree();
        console.log(this.data);
      },
      (error: any) => {
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
  // getData(): Observable<any> {
  //   return this.http.get<any>('http://127.0.0.1:5000/api/getPartyOverview'); // Replace with your API endpoint
  // }
}
