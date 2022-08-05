import { TestBed } from '@angular/core/testing';

import { MhnService } from './mhn.service';

describe('MhnService', () => {
  let service: MhnService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MhnService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
