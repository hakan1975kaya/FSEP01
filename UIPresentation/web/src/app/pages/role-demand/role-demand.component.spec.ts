/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RoleProcessStateL22PESComponent } from './role-ProcessStateL22PES.component';

describe('RoleProcessStateL22PESComponent', () => {
  let component: RoleProcessStateL22PESComponent;
  let fixture: ComponentFixture<RoleProcessStateL22PESComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoleProcessStateL22PESComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoleProcessStateL22PESComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
