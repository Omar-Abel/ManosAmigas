import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { RegisterService } from '../../services/register.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: FormGroup;
  showToast: boolean = false;

  constructor(private fb: FormBuilder, private registerService: RegisterService, private router: Router) {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userType: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      repeatPassword: ['', Validators.required]
    }, { validator: this.passwordMatchValidator });
  }

  passwordMatchValidator(form: FormGroup) {
    const password = form.get('password');
    const repeatPassword = form.get('repeatPassword');
    return password && repeatPassword && password.value === repeatPassword.value ? null : { mismatch: true };
  }

  get emailControl() {
    return this.registerForm.get('email');
  }

  get passwordControl() {
    return this.registerForm.get('password');
  }

  get repeatPasswordControl() {
    return this.registerForm.get('repeatPassword');
  }

  register() {
    if (this.registerForm.valid) {
      const formData = this.registerForm.value;
      const userTypeMapping: { [key: string]: number } = {
        organizer: 0,
        volunteer: 1
      };

      const accountType = userTypeMapping[formData.userType as keyof typeof userTypeMapping];

      const data = {
        firstName: formData.firstName,
        lastName: formData.lastName,
        email: formData.email,
        password: formData.password,
        accountType: accountType
      };

      this.registerService.register(data).subscribe(
        response => {
          console.log('Registration successful', response);
          this.showToast = true;
          setTimeout(() => {
            this.router.navigate(['/login']);
          }, 4500);
        },
        error => {
          console.error('Registration error', error);
        }
      );
    }
  }
}
