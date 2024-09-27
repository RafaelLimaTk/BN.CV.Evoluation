/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { OrganizationEnterpriseService } from './organization-enterprise.service';

describe('Service: OrganizationEnterprise', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrganizationEnterpriseService]
    });
  });

  it('should ...', inject([OrganizationEnterpriseService], (service: OrganizationEnterpriseService) => {
    expect(service).toBeTruthy();
  }));
});
