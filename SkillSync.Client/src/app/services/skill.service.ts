import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { lastValueFrom } from 'rxjs';
import { Skill } from '../shared/entities/models/skill';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  constructor(private httpClient: HttpClient, private notificationService: NotificationService, private localStorageService: LocalStorageService) { }

  private readonly httpOptions = jsonHttpOptions;

  async getSkillById(skillId: string) {
    let route = buildRoute(`api/Skill/by-id/${skillId}`);

    let result = this.httpClient.get<Skill>(route, this.httpOptions);

    return await lastValueFrom(result);
  }
}
