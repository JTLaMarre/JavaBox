import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomCodeDisplayComponent } from './room-code-display.component';

describe('RoomCodeDisplayComponent', () => {
  let component: RoomCodeDisplayComponent;
  let fixture: ComponentFixture<RoomCodeDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomCodeDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomCodeDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
