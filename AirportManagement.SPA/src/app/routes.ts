import { Routes } from "@angular/router";
import { PassangerDetailsComponent } from "./passanger/passanger-details/passanger-details.component";
import { PassangerComponent } from "./passanger/passanger.component";
import { PassangerDetailResolver } from "./_resolvers/passanger-detail.resolver";


export const appRoutes: Routes =[
    { path:'passanger', component :PassangerComponent},
    { path:'passanger/:id', component :PassangerDetailsComponent, resolve:{passanger:PassangerDetailResolver}},
{ path:'**', redirectTo : '',pathMatch:'full'}
];