import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { catchError, Observable, of } from "rxjs";
import { PaginatedResult } from "../_models/pagination";
import { Passangers } from "../_models/Passangers";
import { PassangerWithDetails } from "../_models/PassangerWithDetails";
import { AlertifyService } from "../_services/alertify.service";
import { PassangerService } from "../_services/passanger.service";

@Injectable()
export class PassangerListResolver implements Resolve<PaginatedResult<Passangers[]>>{
    pageNumber = 1;
    pageSize = 5;

    constructor(private passangerService: PassangerService, 
        private router:Router, private alertify:AlertifyService){}

        resolve(route: ActivatedRouteSnapshot): Observable<PaginatedResult<Passangers[]>>{
            console.log('List Resolver'+this.pageNumber+' '+this.pageSize);
            return this.passangerService.getPassangers(this.pageNumber, this.pageSize).pipe(
                catchError(error => {
                    console.log(error);
                    this.alertify.error('Problem retreiving Data');
                    return of();
                })
            );
        }
}