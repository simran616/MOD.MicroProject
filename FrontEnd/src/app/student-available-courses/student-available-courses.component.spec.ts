import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentAvailableCoursesComponent } from './student-available-courses.component';

describe('StudentAvailableCoursesComponent', () => {
  let component: StudentAvailableCoursesComponent;
  let fixture: ComponentFixture<StudentAvailableCoursesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentAvailableCoursesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentAvailableCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
