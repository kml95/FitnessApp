import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDietComponent } from './user-diet.component';

describe('UserDietComponent', () => {
  let component: UserDietComponent;
  let fixture: ComponentFixture<UserDietComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserDietComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
