import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';


@Component({
  selector: 'app-search-course',
  templateUrl: './search-course.component.html',
  styleUrls: ['./search-course.component.scss']
})
export class SearchCourseComponent implements OnInit {

  constructor(private _course : CourseService) { }

  searchedResults=[]
  
  ngOnInit() {
    this.searchedResults=this._course.courselist;
  }


}
