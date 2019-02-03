import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryDietComponent } from './history-diet.component';

describe('HistoryDietComponent', () => {
  let component: HistoryDietComponent;
  let fixture: ComponentFixture<HistoryDietComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoryDietComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoryDietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
