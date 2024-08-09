import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
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
  selector: 'app-activity-list',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.css']
})
export class ActivityListComponent {
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
    {
      id: 'actividad4',
      title: 'Medioambiental: Conservación de ecosistemas',
      beneficioActividad: 'Mantener el medio ambiente en buen estado',
      image: 'assets/medioambiental.jpeg',
      location: 'Provincia G, Municipio H',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 30),
      detailedDescription: 'Participa en la reforestación y limpieza de áreas naturales para preservar el medio ambiente.',
      meetingPoint: 'Parque Natural de Provincia G',
      peopleNeeded: 15
    },
    {
      id: 'actividad5',
      title: 'Bienestar Animal: Cuidado y rescate',
      beneficioActividad: 'Mantener limpia la casa de una pareja de ancianos',
      image: 'assets/bienestar-animal.jpeg',
      location: 'Provincia I, Municipio J',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 30),
      detailedDescription: 'Ayuda en el cuidado diario de los animales y participa en rescates de mascotas abandonadas.',
      meetingPoint: 'Refugio de Animales de Provincia I',
      peopleNeeded: 6
    },
    {
      id: 'actividad6',
      title: 'Salud: Jornadas médicas comunitarias',
      beneficioActividad: 'Mantener limpia la casa de una pareja de ancianos',
      image: 'assets/salud.jpeg',
      location: 'Provincia K, Municipio L',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 30),
      detailedDescription: 'Ofrece apoyo en la organización y ejecución de jornadas de salud para comunidades de bajos recursos.',
      meetingPoint: 'Centro de Salud de Provincia K',
      peopleNeeded: 20
    },
    {
      id: 'actividad7',
      title: 'Comunidad: Integración y desarrollo social',
      beneficioActividad: 'Mantener limpia la casa de una pareja de ancianos',
      image: 'assets/comunidad.jpeg',
      location: 'Provincia M, Municipio N',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 10),
      detailedDescription: 'Organiza y participa en eventos que fomenten la cohesión social y el desarrollo comunitario.',
      meetingPoint: 'Casa de la Cultura de Provincia M',
      peopleNeeded: 12
    },
    {
      id: 'actividad8',
      title: 'Culinaria: Talleres de cocina saludable',
      beneficioActividad: 'Mantener limpia la casa de una pareja de ancianos',
      image: 'assets/culinaria.jpeg',
      location: 'Provincia O, Municipio P',
      startdate: this.createDate(2024, 2, 1),
      enddate: this.createDate(2024, 8, 30),
      detailedDescription: 'Aprende y enseña recetas saludables que promuevan una buena nutrición dentro de la comunidad.',
      meetingPoint: 'Centro Gastronómico de Provincia O',
      peopleNeeded: 7
    }
  ];

  isModalOpen = false;
  selectedActivity: Activity | null = null;
  showAlert = false;
  intervalId: any;
  accountType: number = 1; 
  currentUserId: number = 0;

  constructor(private router: Router) { 
    this.intervalId = setInterval(() => {
      this.updateRemainingTime();
    }, 60000);
    this.updateRemainingTime();
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

  enrollInActivity(activity: Activity) {
    console.log(`Inscribirse en la actividad: ${activity.title}`);
    // Aquí puedes agregar la lógica para inscribirse en la actividad
    this.showAlert = true;
    setTimeout(() => this.showAlert = false, 5000);
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
    return new Date(year, month - 1, day);
  }

  isHost(): boolean {
    return this.accountType === 0;
  }

  redirectToListActivities() {
    this.router.navigate(['/listActivities']);
  }
}