import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';
import { ActivityService } from '../../services/activity.service';
import { OnInit } from '@angular/core';
import { Activity } from '../../models/activity';


@Component({
  selector: 'app-activity-list',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.css']
})

export class ActivityListComponent implements OnInit {
  activities: Activity[] = [];
  selectedActivity: Activity | null = null;
  isModalOpen: boolean = false;

  constructor(private activityService: ActivityService) { }

  ngOnInit(): void {
    this.loadActivities();
  }

  loadActivities(): void {
    this.activityService.getActivities().subscribe({
      next: (response) => {
        if (response.success === 1) {
          this.activities = response.data;
        } else {
          console.error('Error al cargar actividades');
        }
      },
      error: (error) => {
        console.error('Error al obtener actividades', error);
      }
    });
  }

  showDetails(activity: Activity): void {
    this.selectedActivity = activity;
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
    this.selectedActivity = null;
  }

  enrollInActivity(activity: Activity): void {
    // Implementar la lógica para inscribirse en la actividad
    console.log('Inscribirse en la actividad:', activity);
  }

  deleteActivity(activity: Activity): void {
    // Implementar la lógica para eliminar la actividad
    console.log('Eliminar la actividad:', activity);
  }
}