import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-button',
  templateUrl: './register-button.component.html',
  styleUrl: './register-button.component.css'
})
export class RegisterButtonComponent {
  constructor(private router: Router) { }

  navigateToChooseRegisterProviderPage() {
    this.router.navigate(['/choose-register-provider']);
  }
}
