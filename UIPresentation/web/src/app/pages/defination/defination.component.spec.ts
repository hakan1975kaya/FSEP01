import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefinationComponent } from './defination.component';

describe('DefinationComponent', () => {
  let component: DefinationComponent;
  let fixture: ComponentFixture<DefinationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DefinationComponent]
    });
    fixture = TestBed.createComponent(DefinationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
