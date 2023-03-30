import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthycheckComponent } from './healthycheck.component';

describe('HealthycheckComponent', () => {
  let component: HealthycheckComponent;
  let fixture: ComponentFixture<HealthycheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthycheckComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HealthycheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
