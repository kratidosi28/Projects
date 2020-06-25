import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteStudentDetailsComponent } from './delete-student-details.component';

describe('DeleteStudentDetailsComponent', () => {
  let component: DeleteStudentDetailsComponent;
  let fixture: ComponentFixture<DeleteStudentDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteStudentDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteStudentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
