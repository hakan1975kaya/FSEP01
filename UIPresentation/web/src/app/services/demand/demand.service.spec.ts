/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DemandService } from './demand.service';

describe('Service: Demand', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DemandService]
    });
  });

  it('should ...', inject([DemandService], (service: DemandService) => {
    expect(service).toBeTruthy();
  }));
});
