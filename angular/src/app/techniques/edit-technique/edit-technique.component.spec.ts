import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTechniqueComponent } from './edit-technique.component';

describe('EditTechniqueComponent', () => {
  let component: EditTechniqueComponent;
  let fixture: ComponentFixture<EditTechniqueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTechniqueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTechniqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
