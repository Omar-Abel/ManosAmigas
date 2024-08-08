import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-create-activities',
  standalone: true,
  templateUrl: './create-activities.component.html',
  styleUrl: './create-activities.component.css',
  imports: [RouterModule, NavbarComponent]
})
export class CreateActivitiesComponent {

}
