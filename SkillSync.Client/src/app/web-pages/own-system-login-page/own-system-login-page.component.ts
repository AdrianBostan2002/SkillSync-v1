import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { LocalStorageService } from '../../services/local-storage.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginRequest } from '../../shared/entities/requests/login-request';

@Component({
  selector: 'app-own-system-login-page',
  templateUrl: './own-system-login-page.component.html',
  styleUrl: './own-system-login-page.component.css'
})
export class OwnSystemLoginPageComponent {
  constructor
    (
      private authenticationService: AuthenticationService,
      private localStorageService: LocalStorageService,
      private router: Router,
      private formBuilder: FormBuilder
    ) { }

  welcomeMessage: string = "Welcome back!";
  registerMessage: string = "Access your account by entering your credentials below.";

  loginForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
    password: ['', Validators.required]
  });

  async loginButton() {
    if (!this.loginForm.valid) {
      return;
    }

    let emailInput = this.loginForm.controls['email'].value;
    let passwordInput = this.loginForm.controls['password'].value

    if (emailInput != null && passwordInput != null) {
      let newLoginRequest: LoginRequest = {
        email: emailInput,
        password: passwordInput
      }

      let result = await this.authenticationService.ownSysLoginRequest(newLoginRequest);

      this.authenticationService.userLoggedIn.next(true);
      this.localStorageService.setItem("token", result.token);

      this.router.navigate(["/landing-page"]);
    }
  }
}
