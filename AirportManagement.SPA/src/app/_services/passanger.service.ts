import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { Passangers } from '../_models/Passangers';
import { PassangerWithDetails } from '../_models/PassangerWithDetails';

const httpOptions = {
  headers:new HttpHeaders({
    'Authorization':'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class PassangerService {
  baseUrl= environment.apiUrl;

  constructor(private http:HttpClient) { }

  // https://localhost:7139/api/Passangers/Get-All-Passangers

  getPassangers(page: number, itemsPerPage: number):Observable<PaginatedResult<Passangers[]>>{
    const paginatedResult: PaginatedResult<Passangers[]> = new PaginatedResult<Passangers[]>();

    let parameters = new HttpParams();

    if(page != null && itemsPerPage != null)
    {
      parameters = parameters.append('pageNumber', page);
      parameters = parameters.append('pageSize', itemsPerPage);
    }

    return this.http.get<Passangers[]>(this.baseUrl+'Passangers/Get-All-Passangers',
    {headers: httpOptions.headers,observe: 'response', params: parameters})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if(response.headers.get('Pagination')!=null){
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination') as string)
          }
          return paginatedResult;
        })
      );
  }

  getPassangerWithDetailsById(id: string):Observable<PassangerWithDetails>{
    return this.http.get<PassangerWithDetails>(this.baseUrl+'Passangers/Get-Passanger-With-Details-By-Id/'+id,httpOptions);    
  }

  updatePassanger(id:string, Passanger:Passangers){
    console.log(Passanger);
    return this.http.put(this.baseUrl + 'Passangers/update-passanger-by-id/'+id,Passanger,httpOptions);
  }
}
