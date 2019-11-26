import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.scss']
})
export class MentorProfileComponent implements OnInit {

  mentorprofile ={}
  constructor( private _profileservice:ProfileService,
              private _router: Router,
              private _route:ActivatedRoute) { }
    email : any
  ngOnInit() {
    this.email = this._profileservice.getEmail()
    console.log('**************'+this.email)
    this._profileservice.getMentorByEmail(this.email)
    .subscribe(
      res=>{
        console.log(res);
        this.mentorprofile=res;
        console.log(this.mentorprofile)
      },
      err=>console.log(err)
    )
  }

}