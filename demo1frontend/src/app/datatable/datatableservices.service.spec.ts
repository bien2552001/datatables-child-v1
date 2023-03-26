import { TestBed } from '@angular/core/testing';

import { DatatableservicesService } from './datatableservices.service';

describe('DatatableservicesService', () => {
  let service: DatatableservicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatatableservicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
