import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { ActivityService } from '../../services/activity.service'; 


@Component({
  selector: 'app-create-activities',
  standalone: true,
  templateUrl: './create-activities.component.html',
  styleUrls: ['./create-activities.component.css'],
  imports: [RouterModule, NavbarComponent, CommonModule, ReactiveFormsModule, RouterModule]
})
export class CreateActivitiesComponent {
  activityForm: FormGroup;
  image: File | null = null;
  showToast: boolean = false;
  

  constructor(private fb: FormBuilder, private activityService: ActivityService, private router: Router) {
    this.activityForm = this.fb.group({
      title: ['', Validators.required],
      category: ['', Validators.required],
      benefits: ['', Validators.required],
      location: ['', Validators.required],
      meetingPoint: ['', Validators.required],
      peopleRequired: [0, [Validators.required, Validators.min(1)]],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      image: [ '', Validators.required],
      description: ['', Validators.required]
    });
  }

  ShowImage(event: any) {
    const file = (event.target as HTMLInputElement).files![0];
    this.image = file;
  }

  onSubmit() {
    if (this.activityForm.valid) {
      const formData = new FormData();
      
      formData.append('title', this.activityForm.value.title);
      formData.append('description', this.activityForm.value.description);
      formData.append('category', this.activityForm.value.category);
      formData.append('location', this.activityForm.value.location);
      formData.append('meetingPoint', this.activityForm.value.meetingPoint);
      formData.append('peopleRequired', this.activityForm.value.peopleRequired.toString());
      formData.append('benefits', this.activityForm.value.benefits);
      formData.append('startDate', this.activityForm.value.startDate);
      formData.append('endDate', this.activityForm.value.endDate);
      if (this.image){
      formData.append('image', this.image);
      }
      const currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
      if (currentUser && currentUser.id) {
        formData.append('hostId', currentUser.id.toString());
      }

      this.activityService.addActivity(formData).subscribe({
        next: (response) => {
          if (response.success === 1) {

            console.log('Actividad creada con éxito!');
            this.showToast = true;
            setTimeout(() => {
              this.router.navigate(['/']);
            }, 3000);


          } else {
            console.error('Error al crear actividad');
          }
        },
        error: (error) => {
          console.error('Error al enviar la actividad', error);
        }
      });
    } else {
      console.log('Formulario inválido');
    }
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    this.image = file; 
  }
}
