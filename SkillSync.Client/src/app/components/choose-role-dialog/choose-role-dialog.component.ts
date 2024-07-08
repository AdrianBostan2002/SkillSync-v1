import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';
import { RoleType } from '../../shared/enums/role-type';
import { SocialProvider } from '../../shared/enums/social-provider';
import { Router } from '@angular/router';
import { SocialProviderRegisterRequest } from '../../shared/entities/requests/register-request';
import { LocalStorageService } from '../../services/local-storage.service';

@Component({
  selector: 'app-choose-role-dialog',
  templateUrl: './choose-role-dialog.component.html',
  styleUrl: './choose-role-dialog.component.css'
})
export class ChooseRoleDialogComponent {
  private token = "";
  private role?: RoleType;
  private socialProvider?: SocialProvider;
  isDialogVisible = true;

  dialogMessage: string = "Select account type";

  constructor
    (
      private route: ActivatedRoute,
      private router: Router,
      private authenticationService: AuthenticationService,
      private localStorageService: LocalStorageService
    ) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const token = params['code'];
      const socialProvider = params['social-provider'];

      this.token = token;

      if (socialProvider === "google") {
        this.socialProvider = SocialProvider.Google;
      }
      else if (socialProvider === "own-system") {
        this.socialProvider = SocialProvider.OwnSystem;
      }
      else {
        this.socialProvider = SocialProvider.LinkedIn;
      }
    });
  }

  async onWork() {
    this.role = RoleType.Freelancer;

    if (this.socialProvider == SocialProvider.OwnSystem) {
      this.router.navigate(['/register'],
        { queryParams: { 'sp': this.socialProvider, 'r': this.role } });
      return;
    }

    let newRegisterRequest: SocialProviderRegisterRequest = {
      role: RoleType.Freelancer,
      socialProvider: this.socialProvider !== undefined ? this.socialProvider : SocialProvider.OwnSystem,
      accessToken: this.token,
    }

    let registerResponse = await this.authenticationService.socialProviderRegister(newRegisterRequest);

    this.localStorageService.setItem("token", registerResponse.token);
    this.authenticationService.userLoggedIn.next(true);

    this.isDialogVisible = false;
    this.router.navigate(["/freelancer-experience"]);
  }

  async onHire() {
    this.role = RoleType.SkillScout;

    if (this.socialProvider === SocialProvider.OwnSystem) {
      this.router.navigate(['/register'],
        { queryParams: { 'sp': this.socialProvider, 'r': this.role } });
      return;
    }

    let newRegisterRequest: SocialProviderRegisterRequest = {
      role: RoleType.SkillScout,
      socialProvider: this.socialProvider !== undefined ? this.socialProvider : SocialProvider.OwnSystem,
      accessToken: this.token,
    }

    let registerResponse = await this.authenticationService.socialProviderRegister(newRegisterRequest);

    this.localStorageService.setItem("token", registerResponse.token);
    this.authenticationService.userLoggedIn.next(true);

    this.isDialogVisible = false;
    this.router.navigate(["/landing"]);
  }

  
  onBackButton(){
    this.router.navigate(["/choose-register-provider"]); 
  }
}