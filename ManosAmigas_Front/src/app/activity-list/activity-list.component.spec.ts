import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivityListComponent } from './activity-list.component';
import { CommonModule } from '@angular/common'; 

describe('ActivityListComponent', () => {
  let component: ActivityListComponent;
  let fixture: ComponentFixture<ActivityListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ActivityListComponent],
      imports: [CommonModule] 
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ActivityListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
