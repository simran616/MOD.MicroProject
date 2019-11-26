import { Component, OnInit } from '@angular/core';
import {AuthService} from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginUserData = {}
  message = ''
  constructor(private _auth: AuthService,
              private _router: Router) { }

  ngOnInit() {
  }
  loginUser(){
    this._auth.loginUser(this.loginUserData)
    .subscribe(
      res => {
        console.log(res)
        localStorage.setItem('token',res.key)
        // localStorage.setItem('Fname',res.fName)
        // localStorage.setItem('Lname',res.lName)
        localStorage.setItem('Role',res.role)
        localStorage.setItem('Email',res.email)
        // localStorage.setItem('Id',res.id)
        this._router.navigate([''])
      },
      err => {
        this.message = err.error.message;
        
        console.log(err)
      }
    )
    
  }

}

