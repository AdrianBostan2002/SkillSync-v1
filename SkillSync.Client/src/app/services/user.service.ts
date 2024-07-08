import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { lastValueFrom } from 'rxjs';
import { RoleType } from '../shared/enums/role-type';
import { LocalStorageService } from './local-storage.service';
import { GetProfilePictureResponse } from '../shared/entities/responses/get-profile-picture-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, private notificationService: NotificationService, private localStorageService: LocalStorageService) { }

  private readonly httpOptions = jsonHttpOptions;

  async getUserRole() {
    let route = buildRoute("api/User/role");

    let result = this.httpClient.get<RoleType>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getUserProfilePicture() {
    let route = buildRoute("api/User/profile-picture");

    let result = this.httpClient.get<GetProfilePictureResponse>(route, this.httpOptions);

    return await lastValueFrom(result);
  }
}
