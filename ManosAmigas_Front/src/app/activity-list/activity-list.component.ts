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
  showAlert = false;

  constructor(private activityService: ActivityService) { }
  accountType!: number;
  
  ngOnInit(): void {
    this.loadActivities();
    this.loadAccountType();
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
    this.showAlert = true;
    setTimeout(() => this.showAlert = false, 9000 );
    
    console.log('Inscribirse en la actividad:', activity);
  }
  
  deleteActivity(activity: Activity): void {
    if (activity.id) {
      console.log('ID de la actividad a eliminar:', activity.id); // Verificar que el ID sea correcto
      this.activityService.deleteActivity(activity.id).subscribe({
        next: () => {
          this.closeModal();
          this.loadActivities(); // Refrescar la lista después de eliminar la actividad
        },
        error: (error) => {
          console.error('Error al eliminar la actividad', error);
        }
      });
    }
  }
  private loadAccountType(): void {
    // Obtener el objeto del localStorage
    const currentUserString = localStorage.getItem('currentUser');

    if (currentUserString) {
      try {
        // Convertir la cadena JSON a un objeto JavaScript
        const currentUser = JSON.parse(currentUserString);

        // Extraer el accountType
        this.accountType = currentUser.accountType;


      } catch (error) {
        // Manejar errores en el parsing de JSON
        console.error('Error al parsear currentUser desde localStorage:', error);
        this.accountType = 0; // Valor por defecto en caso de error
      }
    } else {
      // Manejar el caso en que no se encuentra 'currentUser'
      this.accountType = 0; // Valor por defecto
    }
  }

}