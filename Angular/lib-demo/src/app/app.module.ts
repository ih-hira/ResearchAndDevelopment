import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TvmazeModule } from 'projects/tvmaze/src/public-api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TvmazeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
}
