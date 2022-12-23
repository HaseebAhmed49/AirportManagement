import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { catchError, Observable, of } from "rxjs";
import { PassangerWithDetails } from "../_models/PassangerWithDetails";
import { AlertifyService } from "../_services/alertify.service";
import { PassangerService } from "../_services/passanger.service";

@Injectable()
export class PassangerDetailResolver implements Resolve<PassangerWithDetails>{
    constructor(private passangerService: PassangerService, 
        private router:Router, private alertify:AlertifyService){}

        resolve(route: ActivatedRouteSnapshot): Observable<PassangerWithDetails>{
            console.log('id');
            console.log('testing')
            return this.passangerService.getPassangerWithDetailsById(route.params['id']).pipe(
                catchError(error => {
                    console.log(error);
                    this.alertify.error('Problem retreiving Data');
                    this.router.navigate(['/passanger']);
                    return of();
                })
            );
        }
}