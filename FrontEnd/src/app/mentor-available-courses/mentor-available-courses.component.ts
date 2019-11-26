import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-mentor-available-courses',
  templateUrl: './mentor-available-courses.component.html',
  styleUrls: ['./mentor-available-courses.component.scss']
})
export class MentorAvailableCoursesComponent implements OnInit {

  courses = []
  mentordetails = {}
  
  constructor(private _courseService: CourseService,
              private _router: Router,
              private _route:ActivatedRoute,
              private _profileService:ProfileService) { }


  ngOnInit() {
    this.render();
  }
   
  mentoremail:any
  AddSkill(id){
    console.log(id)
    this.mentoremail = this._profileService.getEmail()
    this._profileService.getMentorByEmail(this.mentoremail)
    .subscribe(
      res=>{
        console.log(res);
        this.mentordetails = res;
        this._courseService.addskills(id,this.mentordetails).subscribe(
          result => {
            console.log(result);
            this.render();
          }, error => {
            error => console.log(error)
          }
        )
       
      },
      err => console.log(err)
    )
 
  }
  render(){
    this._courseService.getcourses()
    .subscribe(
      res => this.courses =res, 
      err => console.log(err)
    )

  }
 
}
