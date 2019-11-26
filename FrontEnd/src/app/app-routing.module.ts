import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoursesComponent } from './courses/courses.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactComponent } from './contact/contact.component';
import { AddCoursesComponent } from './add-courses/add-courses.component';
import { EditCoursesComponent } from './edit-courses/edit-courses.component';
import { SearchCourseComponent } from './search-course/search-course.component';
import { StudentDashboardComponent } from './student-dashboard/student-dashboard.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { MentorDashboardComponent } from './mentor-dashboard/mentor-dashboard.component';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { CoursesDashboardComponent } from './courses-dashboard/courses-dashboard.component';
import { MentorEnrolledcoursesComponent } from './mentor-enrolledcourses/mentor-enrolledcourses.component';
import { MentorListComponent } from './mentor-list/mentor-list.component';
import { StudentListComponent } from './student-list/student-list.component';
import { MentorProfileComponent } from './mentor-profile/mentor-profile.component';
import { StudentProfileComponent } from './student-profile/student-profile.component';
import { MentorAvailableCoursesComponent } from './mentor-available-courses/mentor-available-courses.component';
import { MentorSkillsComponent } from './mentor-skills/mentor-skills.component';
import { StudentAvailableCoursesComponent } from './student-available-courses/student-available-courses.component';
import { MentorNotificationComponent } from './mentor-notification/mentor-notification.component';
import { StudentNotificationComponent } from './student-notification/student-notification.component';
import { StudentEnrolledCoursesComponent } from './student-enrolled-courses/student-enrolled-courses.component';
import { PaymentPageComponent } from './payment-page/payment-page.component';



const routes: Routes = [
  {path:"" ,component:HomepageComponent},
  {path:"register",component:RegisterComponent},
  {path:"login",component:LoginComponent},

  {path:"about_us",component:AboutUsComponent},
  {path:"contact",component:ContactComponent},

  {path:"courses",component:CoursesComponent},
  {path:"add-courses",component:AddCoursesComponent},
  {path:"search-courses",component:SearchCourseComponent},
  {path:"edit-courses/:id",component:EditCoursesComponent},
  {path:"admin-profile",component:AdminProfileComponent},
  {path:"mentor-profile",component:MentorProfileComponent},
  {path:"student-profile",component:StudentProfileComponent},
  
  {path:"student-dashboard",component:StudentDashboardComponent},
  {path:"admin-dashboard",component:AdminDashboardComponent},
  //{path:"admin-dashboard", redirectTo: "admin-profile", pathMatch: "full"},
  {path:"mentor-dashboard",component:MentorDashboardComponent},
  {path:"courses-dashboard",component:CoursesDashboardComponent},
  
  {path:"mentor-list",component:MentorListComponent},
  {path:"student-list",component:StudentListComponent},

  {path:"mentor-enrolled-courses",component:MentorEnrolledcoursesComponent},
  {path:"student-enrolled-courses",component:StudentEnrolledCoursesComponent},

  {path:"mentor-available-courses",component:MentorAvailableCoursesComponent},
  {path:"student-available-courses",component:StudentAvailableCoursesComponent},

  {path:"mentor-skills",component:MentorSkillsComponent},
  {path:"mentor-notification",component:MentorNotificationComponent},
  {path:"student-notification",component:StudentNotificationComponent},
  {path:"payment-page/:id",component:PaymentPageComponent},
  //{path:"student-notification",component:StudentNotificationComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
