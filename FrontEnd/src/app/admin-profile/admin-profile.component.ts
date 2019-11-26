import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.scss']
})
export class AdminProfileComponent implements OnInit {

  adminprofile ={}
  constructor( private _profileservice:ProfileService) { }

  ngOnInit() {
    this._profileservice.getAdminDetails()
      .subscribe(
        res => this.adminprofile = res,
        err => console.log(err),
      )
  }

}
