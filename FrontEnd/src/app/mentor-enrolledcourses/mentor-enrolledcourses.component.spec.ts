import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorEnrolledcoursesComponent } from './mentor-enrolledcourses.component';

describe('MentorEnrolledcoursesComponent', () => {
  let component: MentorEnrolledcoursesComponent;
  let fixture: ComponentFixture<MentorEnrolledcoursesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MentorEnrolledcoursesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MentorEnrolledcoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
