import { TestBed } from '@angular/core/testing';

import { PassangerService } from './passanger.service';

describe('PassangerService', () => {
  let service: PassangerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PassangerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
