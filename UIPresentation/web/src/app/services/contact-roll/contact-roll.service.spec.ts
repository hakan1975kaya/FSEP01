/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ContactRollService } from './contact-roll.service';

describe('Service: ContactRoll', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContactRollService]
    });
  });

  it('should ...', inject([ContactRollService], (service: ContactRollService) => {
    expect(service).toBeTruthy();
  }));
});
