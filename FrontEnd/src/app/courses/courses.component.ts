import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  courses = []
  constructor(private _courseService: CourseService,
              private _router: Router,
              private _route:ActivatedRoute) { }

  id:any
  ngOnInit() {
    this._courseService.getadmincourses()
    .subscribe(
      res => this.courses =res, 
      err => console.log(err)
    )
  }

  Delete(id){
    this._courseService.deletecourse(id)
    .subscribe(
      res=> {
        //console.log(res)
        this._router.navigate([''])
      },
      err=>console.log(err)
    )

  }
 

}
