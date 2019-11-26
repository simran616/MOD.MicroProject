import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-courses',
  templateUrl: './add-courses.component.html',
  styleUrls: ['./add-courses.component.scss']
})
export class AddCoursesComponent implements OnInit {

  AddCourseData={}
  
  constructor(private _course: CourseService,
              private _router: Router,
              private _route: ActivatedRoute ) {}

  ngOnInit() {
   
  }

  AddCourse(){
    console.log(this.AddCourseData);
    this._course.addcourse(this.AddCourseData)
    .subscribe(
      res=> {
        console.log(res)
        localStorage.setItem('courseid', res.Id)
        this._router.navigate(['/courses-dashboard'])
      },
      err=> console.log(err)
    )
  }
 

}
