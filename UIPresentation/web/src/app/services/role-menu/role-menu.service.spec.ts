/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RoleMenuService } from './role-menu.service';

describe('Service: RoleMenu', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoleMenuService]
    });
  });

  it('should ...', inject([RoleMenuService], (service: RoleMenuService) => {
    expect(service).toBeTruthy();
  }));
});
