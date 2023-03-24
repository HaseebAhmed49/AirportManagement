import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassangerInsertComponent } from './passanger-insert.component';

describe('PassangerInsertComponent', () => {
  let component: PassangerInsertComponent;
  let fixture: ComponentFixture<PassangerInsertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PassangerInsertComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PassangerInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
