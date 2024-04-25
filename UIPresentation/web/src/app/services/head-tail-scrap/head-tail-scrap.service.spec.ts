import { TestBed } from '@angular/core/testing';

import { HeadTailScrapService } from './head-tail-scrap.service';

describe('HeadTailScrapService', () => {
  let service: HeadTailScrapService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HeadTailScrapService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
