import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuantitiesComponent } from './quantities.component';

describe('QuantitiesComponent', () => {
  let component: QuantitiesComponent;
  let fixture: ComponentFixture<QuantitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuantitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuantitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
