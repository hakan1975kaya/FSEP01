/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DensityService } from './density.service';

describe('Service: Density', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DensityService]
    });
  });

  it('should ...', inject([DensityService], (service: DensityService) => {
    expect(service).toBeTruthy();
  }));
});
