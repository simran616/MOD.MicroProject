import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoursesDashboardComponent } from './courses-dashboard.component';

describe('CoursesDashboardComponent', () => {
  let component: CoursesDashboardComponent;
  let fixture: ComponentFixture<CoursesDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoursesDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoursesDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
