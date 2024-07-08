import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-button',
  templateUrl: './login-button.component.html',
  styleUrl: './login-button.component.css'
})
export class LoginButtonComponent {

  constructor(private router: Router) { }

  redirectToChooseLoginProviderPage() {
    this.router.navigate(['/choose-login-provider']);
  }
}
