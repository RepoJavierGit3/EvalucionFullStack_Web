import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { CreateUserRequest } from '../../models/user';

@Component({
  selector: 'app-user-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.scss'
})
export class UserFormComponent {
  @Output() userCreated = new EventEmitter<void>();

  user: CreateUserRequest = {
    firstName: '',
    lastName: '',
    email: ''
  };

  loading = false;
  error: string | null = null;

  constructor(private userService: UserService) {}

  onSubmit(): void {
    if (!this.isFormValid()) {
      this.error = 'Please fill in all fields correctly';
      return;
    }

    this.loading = true;
    this.error = null;

    this.userService.createUser(this.user).subscribe({
      next: () => {
        this.resetForm();
        this.loading = false;
        this.userCreated.emit();
      },
      error: (err) => {
        this.error = 'Error creating user';
        this.loading = false;
        console.error('Error creating user:', err);
      }
    });
  }

  resetForm(): void {
    this.user = {
      firstName: '',
      lastName: '',
      email: ''
    };
    this.error = null;
  }

  isFormValid(): boolean {
    return this.user.firstName.trim() !== '' && 
           this.user.lastName.trim() !== '' && 
           this.user.email.trim() !== '' &&
           this.isValidEmail(this.user.email);
  }

  isValidEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }
}
