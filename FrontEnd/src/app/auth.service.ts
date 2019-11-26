import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})

export class AuthService {

   _registerUrl = "http://localhost:9095authservice/register"; 
   _loginrUrl = "http://localhost:9095authservice/login";

   _editstudentprofileUrl = "http://localhost:9095studentservice";
 
  
  constructor(private http: HttpClient, private _router: Router) { }

  registerUser(user){
    console.log(user);
    return this.http.post<any>(this._registerUrl, user)
  }
  
  loginUser(user){
    return this.http.post<any>(this._loginrUrl, user)
  }
  loggedIn(){
    return !!localStorage.getItem('token')
  }
  logout(){
    localStorage.removeItem('token')
    this._router.navigate([''])
  }

  isAdmin(){
    let role= localStorage.getItem('Role')
    if (role=='1')
    {return true;}
    else
      {return false;}
  }
  isMentor(){
    let role= localStorage.getItem('Role')
    if (role=='2')
    {return true;}
    else
      {return false;}
  }
  isStudent(){
    let role= localStorage.getItem('Role')
    if (role=='3')
    {return true;}
    else
      {return false;}
  }
  

  editstudentprofile(studentprofile){
   console.log(studentprofile)
    return this.http.post<any>(this._editstudentprofileUrl ,studentprofile)
  }

}
