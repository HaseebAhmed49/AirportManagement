import { Routes } from "@angular/router";
import { PassangerDetailsComponent } from "./passanger/passanger-details/passanger-details.component";
import { PassangerInsertComponent } from "./passanger/passanger-insert/passanger-insert/passanger-insert.component";
import { PassangerComponent } from "./passanger/passanger.component";
import { PassangerDetailResolver } from "./_resolvers/passanger-detail.resolver";
import { PassangerListResolver } from "./_resolvers/passanger-list.resolver";


export const appRoutes: Routes =[
    { path:'passanger', component :PassangerComponent, resolve:{passanger:PassangerListResolver}},
    { path:'passanger/:id', component :PassangerDetailsComponent, resolve:{passanger:PassangerDetailResolver}},
    { path:'passanger/create', component :PassangerInsertComponent},
{ path:'**', redirectTo : '',pathMatch:'full'}
];