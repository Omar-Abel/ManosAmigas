// app.routes.ts
import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ContactComponent } from './contact/contact.component';
import { ActivityListComponent } from './activity-list/activity-list.component';
import {CreateActivitiesComponent} from '../app/create-activities/create-activities.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'listActivities', component: ActivityListComponent },
  { path: 'createActivities', component: CreateActivitiesComponent },
];

export { routes };







