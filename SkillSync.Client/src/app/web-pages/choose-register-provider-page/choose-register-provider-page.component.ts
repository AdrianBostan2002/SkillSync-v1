import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { ExternalAuthDto } from '../../shared/entities/requests/external-auth-dto';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-choose-register-provider-page',
  templateUrl: './choose-register-provider-page.component.html',
  styleUrl: './choose-register-provider-page.component.css'
})
export class ChooseRegisterProviderPageComponent {
  private linkedInToken?: string;
  private extAuthChangeSubscription?: Subscription

  dialogTypeMessageRegister: string = "Create new account";
  redirectToAuthenticationTypeMessageRegister: string = "Already have an account? Sign in";

  constructor
    (
      private authenticationService: AuthenticationService,
      private route: ActivatedRoute,
      private router: Router
    ) { }

  async ngOnInit() {
    this.linkedInToken = this.route.snapshot.queryParams["code"];

    if (this.linkedInToken != undefined) {
      await this.authenticationService.linkedInLogin(this.linkedInToken);
      this.authenticationService.userLoggedIn.next(true);
    }

    this.authenticationService.extAuthChanged.subscribe(user => {
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
    this.router.navigate(
      ['/choose-role'],
      { queryParams: { code: `${externalAuth.idToken}`, 'social-provider': 'google' } }
    );
  }

  ownSystemButtonPressed() {
    this.router.navigate(
      ['/choose-role'],
      { queryParams: { code: `own-system`, 'social-provider': 'own-system' } }
    );
    return;
  }

  linkedInButtonPressed() {
    let redirectUrl = `${environment.clientUrl}${environment.linkedinRedirectUrlRegister}`;

    if (window) {
      window.location.href = `https://www.linkedin.com/uas/oauth2/authorization?response_type=code&client_id=${this.linkedInCredentials.clientId
        }&redirect_uri=${redirectUrl}&scope=${this.linkedInCredentials.scope}`;
    }
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  ngOnDestroy() {
    this.extAuthChangeSubscription?.unsubscribe();
  }
}
