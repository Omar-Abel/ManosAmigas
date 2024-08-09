import { Component } from '@angular/core';
import { Router } from '@angular/router'; 
import { RouterModule } from '@angular/router'; 

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [ RouterModule ], 
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'] 
})
export class NavbarComponent {
  accountType: number = 1; 

  constructor(private router: Router) {}

  isHost(): boolean {
    return this.accountType === 0;
  }

  redirectToListActivities() {
    this.router.navigate(['/listActivities']); 
  }
}

