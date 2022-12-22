import { Routes } from "@angular/router";
import { PassangerComponent } from "./passanger/passanger.component";


export const appRoutes: Routes =[
    { path:'passanger', component :PassangerComponent},
    { path:'**', redirectTo : '',pathMatch:'full'}
];