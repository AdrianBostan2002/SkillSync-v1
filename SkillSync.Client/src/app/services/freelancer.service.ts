import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { RegisterFreelancerSkillsRequest } from '../shared/entities/requests/register-freelancer-skills-request';
import { lastValueFrom } from 'rxjs';
import { NotificationService } from './notification.service';
import { CompleteFreelancerExperienceRequest } from '../shared/entities/requests/complete-freelancer-experience-request';
import { FreelancerDto } from '../shared/entities/responses/freelancer-dto';
import { FreelancerProjectDto } from '../shared/entities/responses/freelancer-project-dto';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class FreelancerService {

  constructor(private httpClient: HttpClient) { }

  private readonly httpOptions = jsonHttpOptions;

  async getFreelancerById(freelancerId: string) {
    let route = buildRoute(`api/Freelancer/by-id/${freelancerId}`);

    let result = this.httpClient.get<FreelancerDto>(route);

    return await lastValueFrom(result);
  }

  async getFreelancerProfile() {
    let route = buildRoute(`api/Freelancer/own-profile`);

    let result = this.httpClient.get<FreelancerDto>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getFreelancerProjectsByPublishStatus(isPublished: boolean) {
    let route = buildRoute(`api/Freelancer/project-by-publish-status/${isPublished}`);

    let result = this.httpClient.get<FreelancerProjectDto[]>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async setFreelancerSkills(request: RegisterFreelancerSkillsRequest) {
    let route = buildRoute("api/Skill/register-freelancer-skills");

    let result = this.httpClient.post<any>(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async setFreelancerCompletedExperienceLevel(hasCompleted: boolean) {
    let route = buildRoute("api/Freelancer/set-complete-experience-info");

    let result = this.httpClient.patch<any>(route, hasCompleted, this.httpOptions);

    return await lastValueFrom(result);
  }

  async completedFreelancerExperienceLevel(request: CompleteFreelancerExperienceRequest) {
    let route = buildRoute("api/Freelancer/complete-experience-info");

    let result = this.httpClient.patch<any>(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getFreelancerHasCompletedExperienceLevel() {
    let route = buildRoute("api/Freelancer/has-completed-experience-info");

    let result = this.httpClient.get<boolean>(route, this.httpOptions);

    return await lastValueFrom(result);
  }
}
