import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PaginatedResult, Pagination } from '../_models/pagination';
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
  pagination?: Pagination;


  constructor(private passangerService:PassangerService,
    private router:Router,private alertify:AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.passangersData = data['passanger'].result;
      this.pagination = data['passanger'].pagination;
    });
  }

  pageChanged(event: any) : void {
    this.pagination!.currentPage = event.page;
    this.loadPassangers();
  }

  loadPassangers() {
    this.passangerService.getPassangers(this.pagination!.currentPage, this.pagination!.itemsPerPage)
    .subscribe((res: PaginatedResult<Passangers[]>) => {
      this.passangersData = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }
}