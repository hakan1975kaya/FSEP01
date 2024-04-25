/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LubracationRollService } from './lubracation-roll.service';

describe('Service: LubracationRoll', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LubracationRollService]
    });
  });

  it('should ...', inject([LubracationRollService], (service: LubracationRollService) => {
    expect(service).toBeTruthy();
  }));
});
