import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsageAreaComponent } from './usage-area.component';

describe('UsageAreaComponent', () => {
  let component: UsageAreaComponent;
  let fixture: ComponentFixture<UsageAreaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsageAreaComponent]
    });
    fixture = TestBed.createComponent(UsageAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
