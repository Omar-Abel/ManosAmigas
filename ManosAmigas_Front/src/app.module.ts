import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app/app.component';
import { HomeComponent } from './app/home/home.component';
import { ActivitiesComponent } from './app/activities/activities.component';
import { RegisterComponent } from './app/register/register.component';
import { LoginComponent } from './app/login/login.component';
import { ContactComponent } from './app/contact/contact.component';
import { AppRoutingModule } from './app/app-routing.module'; // Import the routing module

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ContactComponent,
    HomeComponent,
    ActivitiesComponent,
    RegisterComponent,
    LoginComponent, 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
