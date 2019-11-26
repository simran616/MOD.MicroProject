import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-student-enrolled-courses',
  templateUrl: './student-enrolled-courses.component.html',
  styleUrls: ['./student-enrolled-courses.component.scss']
})
export class StudentEnrolledCoursesComponent implements OnInit {

  courses={}
  constructor(private _courseservice : CourseService,
    private _profileservice :ProfileService) { }

  studentemail:any
  ngOnInit() {
    this.studentemail =this._profileservice.getEmail()
    this.LoadData();
  }

  LoadData(){
    this._courseservice.studentenrolledcourses(this.studentemail)
    .subscribe(
      res=>{
        console.log(res)
        this.courses=res
      },
      err=>console.log(err)
    )
  }

    Completed(id){
      this._courseservice.completedcourse(id)
      .subscribe(
        res=> {
          console.log(res); 
          this.LoadData();
          
        },
        err=> console.log(err)
      )
    }

}
