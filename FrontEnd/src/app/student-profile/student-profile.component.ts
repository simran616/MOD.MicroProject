import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-profile',
  templateUrl: './student-profile.component.html',
  styleUrls: ['./student-profile.component.scss']
})
export class StudentProfileComponent implements OnInit {
  studentprofile = {}
  constructor(private _profileservice:ProfileService,
    private _router: Router) { }

  email:any
  ngOnInit() {
    this.email = this._profileservice.getEmail()
    console.log('**************'+this.email)
    this._profileservice.getStudentByEmail(this.email)
    .subscribe(
      res=>{
        //console.log(res)
        this.studentprofile=res;
      },
      err=>console.log(err)
    )
  }

}