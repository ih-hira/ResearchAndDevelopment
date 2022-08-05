import { TestBed } from '@angular/core/testing';

import { HttpLocalClientService } from './http-local-client.service';

describe('HttpLocalClientService', () => {
  let service: HttpLocalClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpLocalClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
