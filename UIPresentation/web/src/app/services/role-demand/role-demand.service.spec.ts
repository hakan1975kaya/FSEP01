/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RoleDemandService } from './role-demand.service';

describe('Service: RoleDemand', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoleDemandService]
    });
  });

  it('should ...', inject([RoleDemandService], (service: RoleDemandService) => {
    expect(service).toBeTruthy();
  }));
});
