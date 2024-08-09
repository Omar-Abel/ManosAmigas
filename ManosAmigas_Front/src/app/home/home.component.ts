import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  standalone: true,
  imports: [RouterModule, NavbarComponent]
})
export class HomeComponent { 

  constructor( private route: Router ){}

  goToList(){
    this.route.navigate(['/listActivities'])
  }

}







