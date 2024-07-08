import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { LocalStorageService } from '../../services/local-storage.service';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { ExternalAuthDto } from '../../shared/entities/requests/external-auth-dto';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-choose-login-provider-page',
  templateUrl: './choose-login-provider-page.component.html',
  styleUrl: './choose-login-provider-page.component.css'
})
export class ChooseLoginProviderPageComponent {
  dialogTypeMessageLogin: string = "Sign in to your account";
  redirectToAuthenticationTypeMessageLogin: string = "Don't have an account? Join here";

  private extAuthChangeSubscription?: Subscription

  private linkedInToken?: string;

  constructor
    (
      private authenticationService: AuthenticationService,
      private localStorageService: LocalStorageService,
      private route: ActivatedRoute,
      private router: Router
    ) { }

  async ngOnInit() {
    this.linkedInToken = this.route.snapshot.queryParams["code"];

    if (this.linkedInToken != undefined) {
      await this.authenticationService.linkedInLogin(this.linkedInToken);
      this.authenticationService.userLoggedIn.next(true);
    }

    this.extAuthChangeSubscription = this.authenticationService.extAuthChanged.subscribe(user => {
      const externalAuth: ExternalAuthDto = {
        provider: user.provider,
        idToken: user.idToken
      }

      this.validateExternalAuth(externalAuth);
    });
  }

  linkedInCredentials = {
    clientId: environment.clientId,
    scope: environment.scope
  };

  private async validateExternalAuth(externalAuth: ExternalAuthDto) {
    var response = await this.authenticationService.externalLogin(externalAuth);

    this.localStorageService.setItem("token", response.token);
    this.authenticationService.userLoggedIn.next(true);
    this.router.navigate(["/landing-page"]);
  }

  ownSystemButtonPressed() {
    this.router.navigate(['/login']);
  }

  linkedInButtonPressed() {
    let redirectUrl = `${environment.clientUrl}${environment.linkedinRedirectUrlLogin}`;

    if(window){
      window.location.href = `https://www.linkedin.com/uas/oauth2/authorization?response_type=code&client_id=${this.linkedInCredentials.clientId
        }&redirect_uri=${redirectUrl}&scope=${this.linkedInCredentials.scope}`;
    }
  }

  navigateToRegister() {
    this.router.navigate(['/register']);
  }

  ngOnDestroy() {
    this.extAuthChangeSubscription?.unsubscribe();
  }
}