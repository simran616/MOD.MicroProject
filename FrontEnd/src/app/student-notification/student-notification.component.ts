import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { ProfileService } from '../profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-notification',
  templateUrl: './student-notification.component.html',
  styleUrls: ['./student-notification.component.scss']
})



export class StudentNotificationComponent implements OnInit {

  studentnotification={}
  
  constructor(private _courseservice: CourseService,
    private _profileservice: ProfileService,
      private _router : Router) { }

  studentemail:any
  ngOnInit() {
    this.studentemail = this._profileservice.getEmail();
    this._courseservice.getstudentnotification(this.studentemail)
    .subscribe(
      res=>{console.log(res)
      this.studentnotification=res},
      err=>console.log(err)
    )
  }


}
