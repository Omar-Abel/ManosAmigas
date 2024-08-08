import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-activities',
  standalone: true,
  templateUrl: './create-activities.component.html',
  styleUrls: ['./create-activities.component.css'],
  imports: [RouterModule, NavbarComponent, CommonModule, ReactiveFormsModule]
})
export class CreateActivitiesComponent {
  activityForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.activityForm = this.fb.group({
      title: ['', Validators.required],
      category: ['', Validators.required],
      benefits: ['', Validators.required],
      location: ['', Validators.required],
      meetingPoint: ['', Validators.required],
      peopleRequired: [0, [Validators.required, Validators.min(1)]],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      image: [null, Validators.required],
      description: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.activityForm.valid) {
      console.log(this.activityForm.value);
      // Aquí puedes manejar la lógica de envío, como enviar los datos a tu API
    } else {
      console.log('Formulario inválido');
    }
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    this.activityForm.patchValue({
      image: file
    });
  }
}
