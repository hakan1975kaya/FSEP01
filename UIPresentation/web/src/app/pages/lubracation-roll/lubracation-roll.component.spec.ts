import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LubracationRollComponent } from './lubracation-roll.component';

describe('LubracationRollComponent', () => {
  let component: LubracationRollComponent;
  let fixture: ComponentFixture<LubracationRollComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LubracationRollComponent]
    });
    fixture = TestBed.createComponent(LubracationRollComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
