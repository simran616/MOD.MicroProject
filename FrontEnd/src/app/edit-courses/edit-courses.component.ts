import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-courses',
  templateUrl: './edit-courses.component.html',
  styleUrls: ['./edit-courses.component.scss']
})
export class EditCoursesComponent implements OnInit {

  EditCourseData={}
  constructor(private _course: CourseService,
              private _router: Router,
              private _route:ActivatedRoute) {}
 id:any
  ngOnInit() {
    this.id=parseInt(this._route.snapshot.paramMap.get('id'))
    this._course.getcoursebyId(this.id)
    .subscribe(
      res=>{
        this.EditCourseData=res;
      },
      err=>console.log(err)
    )
  }
  EditCourse(){
    console.log(this.EditCourseData);
    this._course.editcourse(this.id,this.EditCourseData)
    .subscribe(
      res=> {
        //console.log(res)
        this._router.navigate(['/courses-dashboard'])
      },
      err=> console.log(err)
    )
  }
    
  

}
