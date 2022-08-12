import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MhnCampaignListComponent } from './modules/feature/mhn/mhn-campaign-list/mhn-campaign-list.component';


const routes: Routes = [
    { path: 'mhn/campaignlist', component: MhnCampaignListComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
