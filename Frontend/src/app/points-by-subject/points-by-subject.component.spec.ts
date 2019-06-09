import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PointsBySubjectComponent } from './points-by-subject.component';

describe('PointsBySubjectComponent', () => {
  let component: PointsBySubjectComponent;
  let fixture: ComponentFixture<PointsBySubjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PointsBySubjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PointsBySubjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
