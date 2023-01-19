import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  passangersData?: any;
  pagination: any;


  constructor(private passangerService:PassangerService,
    private router:Router,private alertify:AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      console.log(this.passangersData);
      this.passangersData = data['passangers'].result;
      console.log('test');
      console.log(this.passangersData);

      this.pagination = data['passangers'].pagination;
    });

  // getAllPassangers(){
  //   this.passangersList1 = this.passangerService.getPassangers();
  //   this.passangersList = this.passangersList1;
  // }
}
}