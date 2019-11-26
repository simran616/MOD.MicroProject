import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CoursesComponent } from './courses/courses.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './auth.service';
import { CourseService } from './course.service';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactComponent } from './contact/contact.component';
import { AddCoursesComponent } from './add-courses/add-courses.component';
import { EditCoursesComponent } from './edit-courses/edit-courses.component';
import { StudentDashboardComponent } from './student-dashboard/student-dashboard.component';
import { MentorDashboardComponent } from './mentor-dashboard/mentor-dashboard.component';
import { SearchCourseComponent } from './search-course/search-course.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { CoursesDashboardComponent } from './courses-dashboard/courses-dashboard.component';
import { MentorEnrolledcoursesComponent } from './mentor-enrolledcourses/mentor-enrolledcourses.component';
import { MentorListComponent } from './mentor-list/mentor-list.component';
import { StudentListComponent } from './student-list/student-list.component';
import { MentorProfileComponent } from './mentor-profile/mentor-profile.component';
import { StudentProfileComponent } from './student-profile/student-profile.component';
import { MentorAvailableCoursesComponent } from './mentor-available-courses/mentor-available-courses.component';
import { MentorSkillsComponent } from './mentor-skills/mentor-skills.component';
import { MentorNotificationComponent } from './mentor-notification/mentor-notification.component';
import { StudentAvailableCoursesComponent } from './student-available-courses/student-available-courses.component';
import { StudentNotificationComponent } from './student-notification/student-notification.component';
import { StudentPaymentComponent } from './student-payment/student-payment.component';
import { StudentEnrolledCoursesComponent } from './student-enrolled-courses/student-enrolled-courses.component';
import { PaymentPageComponent } from './payment-page/payment-page.component';
import { TokenserviceService } from './tokenservice.service';





@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    CoursesComponent,
    LoginComponent,
    RegisterComponent,
    AboutUsComponent,
    ContactComponent,
    AddCoursesComponent,
    EditCoursesComponent,

    StudentDashboardComponent,
    MentorDashboardComponent,
    SearchCourseComponent,
    AdminDashboardComponent,
    AdminProfileComponent,
    CoursesDashboardComponent,
    MentorEnrolledcoursesComponent,
    MentorListComponent,
    StudentListComponent,
    MentorProfileComponent,
    StudentProfileComponent,
    MentorAvailableCoursesComponent,
    MentorSkillsComponent,
    MentorNotificationComponent,
    StudentAvailableCoursesComponent,
    StudentNotificationComponent,
    StudentPaymentComponent,
    StudentEnrolledCoursesComponent,
    PaymentPageComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AuthService,CourseService,
    { provide : HTTP_INTERCEPTORS, useClass : TokenserviceService, multi : true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
