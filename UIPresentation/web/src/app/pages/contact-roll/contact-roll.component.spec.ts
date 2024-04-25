/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ContactRollComponent } from './contact-roll.component';

describe('ContactRollComponent', () => {
  let component: ContactRollComponent;
  let fixture: ComponentFixture<ContactRollComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactRollComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactRollComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
