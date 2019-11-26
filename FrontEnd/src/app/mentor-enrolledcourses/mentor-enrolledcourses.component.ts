import { Component, OnInit } from '@angular/core';
import { CoursesComponent } from '../courses/courses.component';
import { ProfileService } from '../profile.service';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-mentor-enrolledcourses',
  templateUrl: './mentor-enrolledcourses.component.html',
  styleUrls: ['./mentor-enrolledcourses.component.scss']
})
export class MentorEnrolledcoursesComponent implements OnInit {

  courses ={}

  constructor(private _courseservice :CourseService,
              private _profileservice :ProfileService) { }
    mentoremail:any
  ngOnInit() {
    this.mentoremail =this._profileservice.getEmail()
    this._courseservice.mentorenrolledcourses(this.mentoremail)
    .subscribe(
      res=>{
        console.log(res)
        this.courses=res
      },
      err=>console.log(err)
    )

  }

}