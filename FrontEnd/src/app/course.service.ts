import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { identifierModuleUrl } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  // private _coursesurl = "https://localhost:9095/adminservice/";
  private _coursesurl = "http://localhost:9095adminservice/";
  private _mentorcoursesurl = "http://localhost:9095mentorservice/getCourses";
  private _addcourseurl= "http://localhost:9095adminservice";
  private _editcourseurl= "http://localhost:9095adminservice/";
  private _coursebyidurl= "http://localhost:9095adminservice/";
  private _deletecourseurl= "http://localhost:9095adminservice/";


  private _coursebyNameurl = "http://localhost:9095userservice/search/";

  private _mentoravailablecourse = "http://localhost:9095mentorservice/addskills/";
  private _studentavailablcoursesurl = "http://localhost:9095studentservice/studentavailablecourse";

  private enrolledbystudenturl = "http://localhost:9095studentservice/enrolledbystudent/";

  private _skillsurl = "http://localhost:9095mentorservice/getskills/";
  
  private mentornotificationurl = "http://localhost:9095mentorservice/getnotification/";
  private studentnotificationurl = "http://localhost:9095studentservice/getnotification/";

  private _acceptrequestedcourseurl = "http://localhost:9095mentorservice/acceptRequestedCourse/";
  private _declinerequestedcourseurl = "http://localhost:9095mentorservice/rejectRequestedCourse/";

  private _mentorenrolledcoursesurl ="http://localhost:9095mentorservice/getmentorenrolledcourses/"
  private _studentrenrolledcoursesurl ="http://localhost:9095studentservice/getstudentenrolledcourses/"
  private completedcourseurl ="http://localhost:9095studentservice/completecourse/"
  
  public courselist : any

  constructor(private http: HttpClient) { }

  //view courses
  getcourses(){
    return this.http.get<any>(this._mentorcoursesurl + `/${localStorage.getItem('Email')}`);
  }

  getadmincourses(){
    return this.http.get<any>(this._coursesurl)
  }
  
  //add courses byadmin     
  addcourse(course){
    return this.http.post<any>(this._addcourseurl,course)
  }

  //edit or update courses by admin
  editcourse(id,course){
    return this.http.put<any>(this._editcourseurl + id,course)
  }

  //view course by id
  getcoursebyId(id){
    return this.http.get<any>(this._coursebyidurl + id)

  }

  getcoursebyName(cName){
    //console.log(cName+'*******-----')
    return this.http.get<any>(this._coursebyNameurl+cName)

  }

  deletecourse(id){
    return this.http.delete<any>(this._deletecourseurl + id)
  }

  addskills(id,mentordetails){
    return this.http.post<any>(this._mentoravailablecourse + id, mentordetails)
  }

  getskills(email){
    return this.http.get<any>(this._skillsurl + email)
  }

  getavailablecourses(){
    return this.http.get<any>(this._studentavailablcoursesurl + `/${localStorage.getItem('Email')}`)
  }

  enrollCourse(id,studentdetails){
    return this.http.post<any>(this.enrolledbystudenturl + id, studentdetails);
  }

  getmentornotification(mentoremail){
    return this.http.get<any>(this.mentornotificationurl + mentoremail)
  }

  AcceptRequestedCourse(id){
    return this.http.get<any>(this._acceptrequestedcourseurl + id);
  }
  DeclineRequestedCourse(id){
    return this.http.get<any>(this._declinerequestedcourseurl + id);
  }

  getstudentnotification(studentemail){
    return this.http.get<any>(this.studentnotificationurl + studentemail)
  }

  mentorenrolledcourses(email){
    return this.http.get<any>(this._mentorenrolledcoursesurl + email);
  }
  
  studentenrolledcourses(email){
    return this.http.get<any>(this._studentrenrolledcoursesurl + email);
  }

  completedcourse(id){
    return this.http.get<any>(this.completedcourseurl + id)
  }
  
}
