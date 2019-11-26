import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent implements OnInit {

  studentsList ={}
  constructor(private _profileservice: ProfileService) { }

  ngOnInit() {
    this._profileservice.getstudentsListAdmin()
      .subscribe(
        res => this.studentsList = res,
        err => console.log(err),
      )
  }

  Block(id) {
    this._profileservice.blockById(id).subscribe(data => {
      this._profileservice.getstudentsListAdmin()
      .subscribe(
        res => this.studentsList = res,
        err => console.log(err),
      )
    });
  }

  Unblock(id) {
    this._profileservice.unBlockById(id).subscribe(data => {
      this._profileservice.getstudentsListAdmin()
      .subscribe(
        res => this.studentsList = res,
        err => console.log(err),
      )
    });
  }

}