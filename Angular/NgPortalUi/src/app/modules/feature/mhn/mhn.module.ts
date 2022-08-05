import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MhnCampaignListComponent } from './mhn-campaign-list/mhn-campaign-list.component';
import { MhnService } from './services/mhn.service';
import { HttpClientModule } from '@angular/common/http';
import { HttpLocalClientService } from 'src/app/services/http-local-client.service';



@NgModule({
  declarations: [
    MhnCampaignListComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    MhnCampaignListComponent
  ],
  providers:[MhnService]
})
export class MhnModule { }
