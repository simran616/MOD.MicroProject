import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private _getMentorListUrlByAdmin = "http://localhost:9095adminservice/mentorsList";
  private _getStudentListUrlByAdmin = "http://localhost:9095adminservice/studentsList";
  private _getAdmindetails = "http://localhost:9095adminservice/admindetails";
  private _blockUserUrl = "http://localhost:9095adminservice/blockunblock/";

  private _mentorbyemailurl = "http://localhost:9095mentorservice/mentorProfile/";

  private _studentbyemailurl = "http://localhost:9095studentservice/studentProfile/";

  private _paynowurl = "http://localhost:9095studentservice/pay/";

  constructor(private http: HttpClient) { }



  getmentorsListAdmin() {
    return this.http.get<any>(this._getMentorListUrlByAdmin)
  }

  
  getstudentsListAdmin() {
    return this.http.get<any>(this._getStudentListUrlByAdmin)
  }


  getAdminDetails(){
    return this.http.get<any>(this._getAdmindetails);
  }

  public blockById(id) {
    return this.http.get<any>(this._blockUserUrl+id);
      
  }

  public unBlockById(id) {
    return this.http.get<any>(this._blockUserUrl+id);
  }

  getMentorByEmail(email){
    console.log(email +'###########');
    return this.http.get<any>(this._mentorbyemailurl + email );
  }

  getEmail(){
    return localStorage.getItem('Email');
  }

  getStudentByEmail(email){
    console.log(email +'###########');
    return this.http.get<any>(this._studentbyemailurl + email );
  }

  paynow(id){
    return this.http.get<any>(this._paynowurl + id)
  }
  
}
