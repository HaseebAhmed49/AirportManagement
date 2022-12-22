import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PassangerComponent } from './passanger/passanger.component';
import { AlertifyService } from './_services/alertify.service';
import { PassangerDetailsComponent } from './passanger/passanger-details/passanger-details.component';
import { PassangerDetailResolver } from './_resolvers/passanger-detail.resolver';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PassangerComponent,
    PassangerDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    AlertifyService,
    PassangerDetailResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
