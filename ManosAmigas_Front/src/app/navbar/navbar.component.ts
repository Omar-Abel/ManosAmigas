import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // Importa CommonModule
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  firstName!: string;
  lastName!: string;
  accountType!: number;
  

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.loadAccountType();
  }

  createActivity(){
    this.router.navigate(['/createActivities']);
  }
   Logout(){
    localStorage.clear();
    this.router.navigate(['/login'])
  }

  toHome(){
    this.router.navigate(['/'])
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
        this.firstName = currentUser.firstName;
        this.lastName = currentUser.lastName;

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
