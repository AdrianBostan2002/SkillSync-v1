import { Component } from '@angular/core';
import { TokenService } from '../../services/token.service';
import { removeWhiteSpaceAndCharactersForRoute, toRoleType } from '../../shared/utils';
import { RoleType } from '../../shared/enums/role-type';
import { Nullable } from 'primeng/ts-helpers';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../services/local-storage.service';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../../shared/enums/currency-type';
import { AuthenticationService } from '../../services/authentication.service';
import { FreelancerService } from '../../services/freelancer.service';

@Component({
  selector: 'app-session-header',
  templateUrl: './session-header.component.html',
  styleUrl: './session-header.component.css'
})
export class SessionHeaderComponent {
  logoPath: string = 'assets/resources/logo-white.png';
  avatarPath: string = '';
  role: RoleType | Nullable;
  freelancerRole: RoleType = RoleType.Freelancer;
  selectedCurrency: { label: string, value: CurrencyType } = { label: 'USD', value: CurrencyType.USD };
  currencyOptions = this.currencyConveterService.getCurrencyOptions();

  constructor
    (
      private tokenService: TokenService,
      private authenticationService: AuthenticationService,
      private localStorageService: LocalStorageService,
      private currencyConveterService: CurrencyConverterService,
      private freelancerService: FreelancerService,
      private router: Router
    ) { }

  async ngOnInit() {
    let profilePictureUrl = this.tokenService.getProfilePictureUrl();

    this.avatarPath = profilePictureUrl ? profilePictureUrl : '';

    let tokenRole = await this.tokenService.getRole();

    this.role = toRoleType(tokenRole);

    this.selectedCurrency = this.currencyConveterService.getSelectedCurrency();
  }

  onCurrencyChange(currency: { label: string, value: CurrencyType }) {
    this.currencyConveterService.setSelectedCurrency(currency);
  }

  onAddProject() {
    this.router.navigate(['/post-project']);
  }

  onLogoutClick() {
    this.localStorageService.removeToken();
    this.authenticationService.userLoggedIn.next(false);
    this.router.navigate(['/home']);
  }

  onNavigateToChatClick() {
    this.router.navigate(['/chat']);
  }

  onNavigateToOrdersClick() {
    this.router.navigate(['/orders']);
  }

  async onNavigateToProfileClick() {
    if (this.role == this.freelancerRole) {
      await this.onNavigateToFreelancerProfile();
    }
  }

  onAbout() {
    this.router.navigate(['/about']);
  }

  onContact() {
    this.router.navigate(['/contact']);
  }

  async onNavigateToFreelancerProfile() {
    let name = this.tokenService.getUsername() ?? '';
    let freelancerName = removeWhiteSpaceAndCharactersForRoute(name);

    let freelancerDto = await this.freelancerService.getFreelancerProfile();

    this.router.navigate([`/freelancer/${freelancerName}`], { state: { freelancerDto: freelancerDto } });
  }

  onViewProjects() {
    this.router.navigate(['/freelancer-projects']);
  }
}