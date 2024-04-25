import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TramRollComponent } from './tram-roll.component';

describe('TramRollComponent', () => {
  let component: TramRollComponent;
  let fixture: ComponentFixture<TramRollComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TramRollComponent]
    });
    fixture = TestBed.createComponent(TramRollComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
