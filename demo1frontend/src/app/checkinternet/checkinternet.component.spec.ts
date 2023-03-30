import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckinternetComponent } from './checkinternet.component';

describe('CheckinternetComponent', () => {
  let component: CheckinternetComponent;
  let fixture: ComponentFixture<CheckinternetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheckinternetComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CheckinternetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
