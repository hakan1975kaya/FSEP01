import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadTailScrapComponent } from './head-tail-scrap.component';

describe('HeadTailScrapComponent', () => {
  let component: HeadTailScrapComponent;
  let fixture: ComponentFixture<HeadTailScrapComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeadTailScrapComponent]
    });
    fixture = TestBed.createComponent(HeadTailScrapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
