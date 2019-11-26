import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-mentor-notification',
  templateUrl: './mentor-notification.component.html',
  styleUrls: ['./mentor-notification.component.scss']
})
export class MentorNotificationComponent implements OnInit {

  mentornotification = {}
  acceptedcourse ={}
  declinedcourse ={}

  constructor(private _courseservice: CourseService,
              private _profileservice: ProfileService) { }

  mentoremail:any
  ngOnInit() {
    this.mentoremail = this._profileservice.getEmail();
    this.render();
  }

  AcceptRequestedCourse(id){
    this._courseservice.AcceptRequestedCourse(id)
    .subscribe(
      res=>{console.log(res)
        this.acceptedcourse = res
        this.render();},
      err=>console.log(err)
    )

  }

  DeclineRequestedCourse(id){
    this._courseservice.DeclineRequestedCourse(id)
    .subscribe(
      res=>{console.log(res)
        this.declinedcourse=res
        this.render();},
      err=>console.log(err)
    )
  }

  render(){
    this._courseservice.getmentornotification(this.mentoremail)
    .subscribe(
      res=>{console.log(res)
      this.mentornotification=res},
      err=>console.log(err)
    )

  }

}