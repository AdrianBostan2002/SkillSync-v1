import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { TokenService } from './services/token.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navbar-layout',
  templateUrl: './navbar-layout.component.html',
  styleUrl: './navbar-layout.component.css'
})
export class NavbarLayoutComponent {
  isUserAuthenticated?: boolean;

  private authenticationSubscription?: Subscription;

  constructor(private tokenService: TokenService, private authenticationService: AuthenticationService) {}

  ngOnInit() {
    let role = this.tokenService.getRole();
    if (role != null) {
      this.isUserAuthenticated = true;
    }

    this.authenticationSubscription= this.authenticationSubscription = this.authenticationService.userLoggedIn.subscribe(status => {
      this.isUserAuthenticated = status;
    });
  }

  ngOnDestroy() {
    this.authenticationSubscription?.unsubscribe();
  }
} 