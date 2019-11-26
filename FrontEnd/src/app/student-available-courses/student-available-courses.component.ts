import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-student-available-courses',
  templateUrl: './student-available-courses.component.html',
  styleUrls: ['./student-available-courses.component.scss']
})
export class StudentAvailableCoursesComponent implements OnInit {

  availablecourses=[]
  studentdetails={}

  constructor(private _courseService: CourseService,
              private _router: Router,
              private _route:ActivatedRoute,
              private _profileService:ProfileService) { }

  ngOnInit() {
    this._courseService.getavailablecourses()
    .subscribe(
      res =>{ 
        this.availablecourses =res
        console.log(this.availablecourses)
      }, 
      err => console.log(err)
    )
  }

  studentemail:any
  EnrollNow(id){
    console.log(id)
    this.studentemail = this._profileService.getEmail()
    this._profileService.getStudentByEmail(this.studentemail)
    .subscribe(
      res=>{
        console.log(res);
        this.studentdetails = res;
        this._courseService.enrollCourse(id,this.studentdetails).subscribe(
          result => {
            console.log(result);
            this._router.navigate(['/student-available-courses'])
          }, error => {
            error => console.log(error)
          }
        )
        
      },
      err => console.log(err)
    )
 
  }
}