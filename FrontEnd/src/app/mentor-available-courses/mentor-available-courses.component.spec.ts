import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorAvailableCoursesComponent } from './mentor-available-courses.component';

describe('MentorAvailableCoursesComponent', () => {
  let component: MentorAvailableCoursesComponent;
  let fixture: ComponentFixture<MentorAvailableCoursesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MentorAvailableCoursesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MentorAvailableCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
