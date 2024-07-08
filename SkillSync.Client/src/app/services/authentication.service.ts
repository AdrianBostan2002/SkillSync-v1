import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../shared/entities/requests/login-request';
import { Subject, lastValueFrom } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { LoginResponse } from '../shared/entities/responses/login-response';
import { SocialAuthService, SocialUser } from "@abacritt/angularx-social-login";
import { ExternalAuthDto } from '../shared/entities/requests/external-auth-dto';
import { SocialProvider } from '../shared/enums/social-provider';
import { SocialLoginRequest } from '../shared/entities/requests/social-login-request';
import { SocialProviderRegisterRequest } from '../shared/entities/requests/register-request';
import { RegisterResponse } from '../shared/entities/responses/register-response';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { OwnSysRegisterRequest } from '../shared/entities/requests/ownsys-register-request';
import { OwnSysRegisterResponse } from '../shared/entities/responses/own-sys-register-response';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private authChangeSub = new Subject<boolean>();
  private extAuthChangeSub = new Subject<SocialUser>();
  public authChanged = this.authChangeSub.asObservable();
  public extAuthChanged = this.extAuthChangeSub.asObservable();

  public userLoggedIn = new Subject<boolean>();

  constructor(private httpClient: HttpClient, private localStorageService: LocalStorageService, private externalAuthService: SocialAuthService) {
    this.externalAuthService.authState.subscribe((user) => {
      this.extAuthChangeSub.next(user);
    });
  }

  ngOnInit() {
  }

  readonly httpOptions = jsonHttpOptions;

  public async ownSysLoginRequest(loginRequest: LoginRequest): Promise<LoginResponse> {
    let route: string = buildRoute("login");

    let loginResult = this.httpClient.post<LoginResponse>(route, loginRequest, this.httpOptions);

    return await lastValueFrom(loginResult);
  }

  public externalLogin = async (body: ExternalAuthDto) => {
    let loginRequest: SocialLoginRequest = { authorizationCode: body.idToken, socialProvider: SocialProvider.Google }

    let route: string = buildRoute("social-login");

    let result = this.httpClient.post<LoginResponse>(route, loginRequest, jsonHttpOptions);

    let response = await lastValueFrom(result);

    return response;
  }

  public ownSystemRegister = async (registerRequest: OwnSysRegisterRequest) => {
    const formData = new FormData();
    formData.append('email', registerRequest.email);
    formData.append('password', registerRequest.password);
    formData.append('firstName', registerRequest.firstName);
    formData.append('lastName', registerRequest.lastName);
    formData.append('countryCode', registerRequest.countryCode);
    formData.append('role', registerRequest.role.toString());
    formData.append('profilePicture', registerRequest.profilePicture, registerRequest.profilePicture.name);

    const route: string = buildRoute(`own-system-register`);
    const result = this.httpClient.post<OwnSysRegisterResponse>(route, formData);

    const response = await lastValueFrom(result);

    return response;
  }

  public socialProviderRegister = async (registerRequest: SocialProviderRegisterRequest) => {
    let route: string = buildRoute(`social-provider-register`);

    let result = this.httpClient.post<RegisterResponse>(route, registerRequest, jsonHttpOptions);

    let response = await lastValueFrom(result);

    return response;
  }

  public linkedInLogin = async (authorizationCode: string) => {
    let loginRequest: SocialLoginRequest = { authorizationCode: authorizationCode, socialProvider: SocialProvider.LinkedIn }

    let route: string = buildRoute("social-login");

    let result = this.httpClient.post<LoginResponse>(route, loginRequest, jsonHttpOptions);

    let response = await lastValueFrom(result);

    this.localStorageService.setItem("token", response.token);
    this.userLoggedIn.next(true);

    return response;
  }
}