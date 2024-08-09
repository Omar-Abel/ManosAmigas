import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';


interface Activity {
  id: string;
  title: string;
  beneficioActividad: string;
  image: string;
  location: string;
  startdate: Date;
  enddate: Date;
  detailedDescription: string;
  meetingPoint: string;
  peopleNeeded: number;
  remainingTime?: string;
}

@Component({
  selector: 'app-my-activities',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './my-activities.component.html',
  styleUrl: './my-activities.component.css'
})
export class MyActivitiesComponent {
  activities: Activity[] = [
    {
      id: 'actividad1',
      title: 'Doméstico: Ayuda en tareas del hogar',
      beneficioActividad: 'Mantener limpia la casa de una pareja de ancianos',
      image: 'assets/domestico.jpeg',
      location: 'Provincia A, Municipio B',
      startdate: this.createDate(2024, 2, 2),
      enddate: this.createDate(2024, 8, 9),
      detailedDescription: 'Esta actividad consiste en ayudar con tareas como la limpieza, cocina y organización del hogar para apoyar a familias necesitadas.',
      meetingPoint: 'Centro Comunitario de Provincia A',
      peopleNeeded: 5
    },
    {
      id: 'actividad2',
      title: 'Agricultura: Apoyo en huertos comunitarios',
      beneficioActividad: 'Crear y mantener una siembra sana',
      image: 'assets/agricultura.jpeg',
      location: 'Provincia C, Municipio D',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 30),
      detailedDescription: 'Ayuda a plantar, regar y cosechar en huertos comunitarios, promoviendo la autosuficiencia alimentaria.',
      meetingPoint: 'Plaza principal de Provincia C',
      peopleNeeded: 10
    },
    {
      id: 'actividad3',
      title: 'Educativo: Clases de apoyo escolar',
      beneficioActividad: 'Ayudar con el aprendizaje de los niños para asi formar un mejor futuro',
      image: 'assets/educativo.jpeg',
      location: 'Provincia E, Municipio F',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 30),
      detailedDescription: 'Brinda apoyo educativo a estudiantes, ayudándolos a mejorar su rendimiento académico y habilidades de estudio.',
      meetingPoint: 'Biblioteca Municipal de Provincia E',
      peopleNeeded: 8
    },
  ];

  isModalOpen = false;
  selectedActivity: Activity | null = null;
  intervalId: any;

  constructor() {
    // Configurar el intervalo para actualizar el tiempo restante
    this.intervalId = setInterval(() => {
      this.updateRemainingTime();
    }, 60000); // Actualizar cada minuto
    this.updateRemainingTime(); // Llamar inicialmente para establecer el valor
  }

  ngOnDestroy() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }

  showDetails(activity: Activity) {
    this.selectedActivity = activity;
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
    this.selectedActivity = null;
  }

  deleteActivity(activity: Activity) {
    console.log(`Eliminar actividad: ${activity.title}`);
    this.activities = this.activities.filter(a => a.id !== activity.id);
    this.isModalOpen = false;
  }

  updateRemainingTime() {
    const now = new Date();
    this.activities.forEach(activity => {
      const timeDiff = activity.enddate.getTime() - now.getTime();
      if (timeDiff <= 0) {
        activity.remainingTime = 'Finalizado';
      } else {
        const days = Math.floor(timeDiff / (1000 * 60 * 60 * 24));
        const hours = Math.floor((timeDiff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        const minutes = Math.floor((timeDiff % (1000 * 60 * 60)) / (1000 * 60));
        activity.remainingTime = `${days} días, ${hours} horas, ${minutes} minutos`;
      }
    });
  }

  private createDate(year: number, month: number, day: number): Date {
    // Ajustar el mes para que enero sea 1, febrero sea 2, etc.
    return new Date(year, month - 1, day);
  }
}