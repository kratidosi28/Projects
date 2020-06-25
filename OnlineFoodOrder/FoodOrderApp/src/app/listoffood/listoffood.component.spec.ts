import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListoffoodComponent } from './listoffood.component';

describe('ListoffoodComponent', () => {
  let component: ListoffoodComponent;
  let fixture: ComponentFixture<ListoffoodComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListoffoodComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListoffoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
