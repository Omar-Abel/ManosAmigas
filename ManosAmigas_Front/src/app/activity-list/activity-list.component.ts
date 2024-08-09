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
  accountType!: number;
  email!: string;

  constructor(private activityService: ActivityService) { }
  
  
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

  enrollInActivity() {
    const email = this.email;
  
    this.activityService.sendEmail(email).subscribe({
      next: (response: any) => {
        try {
          if (response.success === 1) {
            console.log('Correo enviado correctamente:', response.data);
            this.showAlert = true;
            setTimeout(() => this.showAlert = false, 14000 );
          } else {
            console.error('Error al enviar correo:', response.message);
          }
        } catch (e) {
          console.error('Error al procesar la respuesta del servidor:', e);
        }
      },
      error: (error) => {
        console.error('Error en la solicitud:', error);
      }
    });
  }
  
  

  deleteActivity(activity: Activity): void {
    if (activity.id) {
      console.log('ID de la actividad a eliminar:', activity.id); 
      this.activityService.deleteActivity(activity.id).subscribe({
        next: () => {
          this.closeModal();
          this.loadActivities();
        },
        error: (error) => {
          console.error('Error al eliminar la actividad', error);
        }
      });
    }
  }
  private loadAccountType(): void {
    const currentUserString = localStorage.getItem('currentUser');

    if (currentUserString) {
      try {
        const currentUser = JSON.parse(currentUserString);

        this.accountType = currentUser.accountType;
        this.email = currentUser.email;


      } catch (error) {
        console.error('Error al parsear currentUser desde localStorage:', error);
      }
    } else {
      this.accountType = 0;
    }
  }

}