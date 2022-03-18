import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTechniqueComponent } from './list-technique.component';

describe('ListTechniqueComponent', () => {
  let component: ListTechniqueComponent;
  let fixture: ComponentFixture<ListTechniqueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListTechniqueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListTechniqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
