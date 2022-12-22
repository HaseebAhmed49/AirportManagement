import { Component, ElementRef, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PassangerWithDetails } from 'src/app/_models/PassangerWithDetails';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PassangerService } from 'src/app/_services/passanger.service';

@Component({
  selector: 'app-passanger-details',
  templateUrl: './passanger-details.component.html',
  styleUrls: ['./passanger-details.component.css']
})
export class PassangerDetailsComponent implements OnInit {
  Passanger!: PassangerWithDetails;

  constructor(private passangerService:PassangerService,
    private alertify:AlertifyService,
    private route:ActivatedRoute,
    private el:ElementRef) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.Passanger = data['passanger'];
    });
  }

}