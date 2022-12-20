import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Passangers } from '../_models/Passangers';

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

  getPassangers():Observable<PaginatedResults<Passangers[]>>{
    return this.http.get<Passangers[]>(this.baseUrl+'Passangers/Get-All-Passangers',httpOptions);
  }

  getPassangerWithDetailsById(id: string):Observable<Passangers>{
    return this.http.get<Passangers>(this.baseUrl+'Passangers/Get-Passanger-With-Details-By-Id/'+id,httpOptions);    
  }

  updatePassanger(id:string, Passanger:Passangers){
    console.log(Passanger);
    return this.http.put(this.baseUrl + 'Passangers/update-passanger-by-id/'+id,Passanger,httpOptions);
  }
}
