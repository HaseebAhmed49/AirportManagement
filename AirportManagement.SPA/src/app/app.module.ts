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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PassangerListResolver } from './_resolvers/passanger-list.resolver';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PassangerInsertComponent } from './passanger/passanger-insert/passanger-insert/passanger-insert.component';

@NgModule({
  declarations: [
    AppComponent,
    PassangerComponent,
    PassangerDetailsComponent,
    PassangerInsertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    PaginationModule,
    ReactiveFormsModule
  ],
  providers: [
    AlertifyService,
    PassangerDetailResolver,
    PassangerListResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
