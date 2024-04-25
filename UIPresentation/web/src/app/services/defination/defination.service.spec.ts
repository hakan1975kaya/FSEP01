/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DefinationService } from './defination.service';

describe('Service: Defination', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DefinationService]
    });
  });

  it('should ...', inject([DefinationService], (service: DefinationService) => {
    expect(service).toBeTruthy();
  }));
});
