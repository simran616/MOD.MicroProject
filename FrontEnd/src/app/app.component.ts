import { Component } from '@angular/core';
import { AuthService } from './auth.service';
import { CourseService } from './course.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Microcredential';

  constructor(private _authService: AuthService,
    private _course: CourseService,
    private _router: Router,
    private _route:ActivatedRoute){}

  Search(coursename){
    console.log('**********'+coursename)
    this._course.getcoursebyName(coursename)
    .subscribe(
      res =>{ 
        console.log('res: ' + JSON.stringify(res));
        //coursename = JSON.stringify(res)
        //this._router.navigate(['/courses'])
        //this.searchedResults=res
        this._course.courselist=res;
        this._router.navigate(['/search-courses'])
        
      }, 
      err => console.log(err)
    )
  }
}
