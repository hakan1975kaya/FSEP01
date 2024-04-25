/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TramRollService } from './tram-roll.service';

describe('Service: TramRoll', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TramRollService]
    });
  });

  it('should ...', inject([TramRollService], (service: TramRollService) => {
    expect(service).toBeTruthy();
  }));
});
