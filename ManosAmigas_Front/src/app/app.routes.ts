import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ContactComponent } from './contact/contact.component';
import { AuthGuard } from '../guards/auth.guard';
import { ActivityListComponent } from './activity-list/activity-list.component';
import {CreateActivitiesComponent} from '../app/create-activities/create-activities.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'activities', component: ActivitiesComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
  { path: 'contact', component: ContactComponent, canActivate: [AuthGuard] },
  { path: 'listActivities', component: ActivityListComponent, canActivate [AuthGuard] },
  { path: 'createActivities', component: CreateActivitiesComponent, canActivate [AuthGuard] },
  { path: '**', redirectTo: '', pathMatch: 'full' }

export { routes };
