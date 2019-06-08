import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UniversityFilterComponent } from './university-filter.component';

describe('UniversityFilterComponent', () => {
  let component: UniversityFilterComponent;
  let fixture: ComponentFixture<UniversityFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UniversityFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UniversityFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
