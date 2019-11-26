import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-mentor-list',
  templateUrl: './mentor-list.component.html',
  styleUrls: ['./mentor-list.component.scss']
})
export class MentorListComponent implements OnInit {

  mentorsList ={}
  constructor(private _profileservice: ProfileService) { }

  ngOnInit() {
    this._profileservice.getmentorsListAdmin()
      .subscribe(
        res => this.mentorsList = res,
        err => console.log(err),
      )
  }
  Block(id) {
    this._profileservice.blockById(id).subscribe(data => {
      this._profileservice.getmentorsListAdmin()
      .subscribe(
        res => this.mentorsList = res,
        err => console.log(err),
      )
    });
  }

  Unblock(id) {
    this._profileservice.unBlockById(id).subscribe(data => {
      this._profileservice.getmentorsListAdmin()
      .subscribe(
        res => this.mentorsList = res,
        err => console.log(err),
      )
    });
  }

}
