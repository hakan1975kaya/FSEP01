/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UsageAreaService } from './usage-Area.service';

describe('Service: UsageArea', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UsageAreaService]
    });
  });

  it('should ...', inject([UsageAreaService], (service: UsageAreaService) => {
    expect(service).toBeTruthy();
  }));
});
