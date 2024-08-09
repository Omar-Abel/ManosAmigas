import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
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
    const currentUserString = localStorage.getItem('currentUser');
    if (currentUserString) {
      try {
        const currentUser = JSON.parse(currentUserString);

        this.accountType = currentUser.accountType;
        this.firstName = currentUser.firstName;
        this.lastName = currentUser.lastName;

      } catch (error) {
        console.error('Error al parsear currentUser desde localStorage:', error);
        this.accountType = 0; 
      }
    } else {
      this.accountType = 0; 
    }
  }
}
