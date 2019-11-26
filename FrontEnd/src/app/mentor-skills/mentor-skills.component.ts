import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-mentor-skills',
  templateUrl: './mentor-skills.component.html',
  styleUrls: ['./mentor-skills.component.scss']
})
export class MentorSkillsComponent implements OnInit {

  skills = []
  constructor(private _courseService: CourseService,
    private _router: Router,
    private _profileService:ProfileService) { }

    mentoremail:any
  ngOnInit() {
    this.mentoremail = this._profileService.getEmail()
    this._courseService.getskills(this.mentoremail)
    .subscribe(
      res => {this.skills =res
        console.log(this.skills)}, 
        
      err => console.log(err)
    )
  }

}