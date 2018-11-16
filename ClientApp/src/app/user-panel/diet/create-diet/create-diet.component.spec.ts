import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDietComponent } from './create-diet.component';

describe('CreateDietComponent', () => {
  let component: CreateDietComponent;
  let fixture: ComponentFixture<CreateDietComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateDietComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
