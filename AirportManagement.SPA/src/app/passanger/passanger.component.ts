import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Passangers } from '../_models/Passangers';
import { AlertifyService } from '../_services/alertify.service';
import { PassangerService } from '../_services/passanger.service';

@Component({
  selector: 'app-passanger',
  templateUrl: './passanger.component.html',
  styleUrls: ['./passanger.component.css']
})
export class PassangerComponent implements OnInit {
  passangersList?: Observable<Passangers[]>;
  passangersList1?: Observable<Passangers[]>;
  massage="";


  constructor(private passangerService:PassangerService,
    private router:Router,private alertify:AlertifyService) { }


  ngOnInit(): void {
    this.getAllPassangers();
  }

  getAllPassangers(){
    this.passangersList1 = this.passangerService.getPassangers();
    this.passangersList = this.passangersList1;
  }
}


