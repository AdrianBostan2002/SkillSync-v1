import { Injectable } from '@angular/core';
import { PostProjectRequest } from '../shared/entities/requests/post-project-request';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NotificationService } from './notification.service';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { lastValueFrom } from 'rxjs';
import { GetProjectPreviewResponse } from '../shared/entities/responses/get-projects-preview-response';
import { GetProjectResponse } from '../shared/entities/responses/get-project-response';
import { ProjectOverviewDto } from '../shared/entities/requests/add-project-steps/project-overview-dto';
import { GetProjectPricingDto } from '../shared/entities/requests/add-project-steps/get-project-pricing-dto';
import { AddOrUpdateProjectPricingDto } from '../shared/entities/requests/add-project-steps/add-or-update-project-pricing-dto';
import { ProjectDescriptionFaqDto } from '../shared/entities/requests/add-project-steps/project-description-faq-dto';
import { GetProjectGalleryDto } from '../shared/entities/requests/add-project-steps/get-project-gallery-dto';
import { PostReviewRequest } from '../shared/entities/requests/post-review-request';
import { FilterProjectQueryParams } from '../shared/entities/requests/query-params/filter-project-query-params';
import { ProjectQueryParams } from '../shared/entities/requests/query-params/project-query-params';
import { ProjectPreviewResponse } from '../shared/entities/responses/project-previews-response';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  postProjectRequest?: PostProjectRequest;

  private readonly httpOptions = jsonHttpOptions;

  constructor(private httpClient: HttpClient, private notificationService: NotificationService) { }

  async postProject(request: PostProjectRequest) {
    let token = localStorage.getItem("token");

    if (token == null || token == "") {
      this.notificationService.displayErrorMessage("Token is not set");
    }

    const formData = new FormData();

    formData.append('skillId', request.skillId);
    formData.append('title', request.title);
    formData.append('description', request.description);
    formData.append('hasPackages', request.hasPackages.toString());

    request.features.forEach((feature, index) => {
      formData.append(`features[${index}].featureId`, feature.featureId);
      formData.append(`features[${index}].basicSelectedValue`, feature.basicSelectedValue);
      formData.append(`features[${index}].standardSelectedValue`, feature.standardSelectedValue ?? "");
      formData.append(`features[${index}].premiumSelectedValue`, feature.premiumSelectedValue ?? "");
    });

    request.frequentlyAskedQuestions.forEach((faq, index) => {
      formData.append(`frequentlyAskedQuestions[${index}].question`, faq.question);
      formData.append(`frequentlyAskedQuestions[${index}].answer`, faq.answer);
    });

    request.uploadedPictures.forEach((file) => {
      formData.append(`uploadedPictures`, file, file.name);
    });

    if (request.uploadedVideo) {
      formData.append(`uploadedVideo`, request.uploadedVideo, request.uploadedVideo.name);
    }

    request.uploadedDocuments.forEach((file) => {
      formData.append(`uploadedDocuments`, file, file.name);
    });

    let route = buildRoute("api/Project");

    let result = this.httpClient.post<any>(route, formData);

    return await lastValueFrom(result);
  }

  async getProjectById(projectId: string) {
    let route = buildRoute(`api/Project/by-id/${projectId}`);

    let result = this.httpClient.get<GetProjectResponse>(route);

    return await lastValueFrom(result);
  }

  async deleteProject(projectId: string) {
    let route = buildRoute(`api/Project/${projectId}`);

    let result = this.httpClient.delete(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async postProjectOverview(request: ProjectOverviewDto) {
    let route = buildRoute(`api/Project/overview`);

    let result = this.httpClient.post(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async putProjectOverview(request: ProjectOverviewDto, projectId: string) {
    let route = buildRoute(`api/Project/overview/${projectId}`);

    let result = this.httpClient.put(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getProjectOverview(projectId: string) {
    let route = buildRoute(`api/Project/overview/${projectId}`);

    let result = this.httpClient.get<ProjectOverviewDto>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async putProjectPricing(request: AddOrUpdateProjectPricingDto, projectId: string) {
    let route = buildRoute(`api/Project/pricing/${projectId}`);

    let result = this.httpClient.put(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getProjectPricing(projectId: string) {
    let route = buildRoute(`api/Project/pricing/${projectId}`);

    let result = this.httpClient.get<GetProjectPricingDto>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async putProjectDescriptionFaq(request: ProjectDescriptionFaqDto, projectId: string) {
    let route = buildRoute(`api/Project/description-faq/${projectId}`);

    let result = this.httpClient.put(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getProjectDescriptionAndFaq(projectId: string) {
    let route = buildRoute(`api/Project/description-faq/${projectId}`);

    let result = this.httpClient.get<ProjectDescriptionFaqDto>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async putProjectGallery(projectId: string, uploadedPictures: File[], uploadedVideo: File | undefined, uploadedDocuments: File[], unmodifiedMediaUrls: string[]) {
    let token = localStorage.getItem("token");

    if (token == null || token == "") {
      this.notificationService.displayErrorMessage("Token is not set");
    }

    const formData = new FormData();

    uploadedPictures.forEach((file) => {
      formData.append(`uploadedPictures`, file, file.name);
    });

    if (uploadedVideo) {
      formData.append(`uploadedVideo`, uploadedVideo, uploadedVideo.name);
    }

    uploadedDocuments.forEach((file) => {
      formData.append(`uploadedDocuments`, file, file.name);
    });

    unmodifiedMediaUrls.forEach((url) => {
      formData.append(`unModifiedMediaUrls`, url);
    });

    let route = buildRoute(`api/Project/gallery/${projectId}`);

    let result = this.httpClient.put(route, formData);

    return await lastValueFrom(result)
  }

  async getProjectGallery(projectId: string) {
    let route = buildRoute(`api/Project/gallery/${projectId}`);

    let result = this.httpClient.get<GetProjectGalleryDto>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async modifyPublishStatus(projectId: string, newStatus: boolean) {
    let route = buildRoute(`api/Project/publish-status/${projectId}`);

    let result = this.httpClient.put(route, newStatus, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getPublishStatus(projectId: string) {
    let route = buildRoute(`api/Project/publish-status/${projectId}`);

    let result = this.httpClient.get<boolean>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getAllProjectPreview() {
    let route = buildRoute("api/Project/all-projects-preview");

    let result = this.httpClient.get<GetProjectPreviewResponse[]>(route);

    return await lastValueFrom(result);
  }

  async getProjectsPreviewBySubcategoryId(subcategoryId: string, queryParams: ProjectQueryParams) {
    let params = this.setProjectQueryParams(queryParams);

    let httpOptions = {
      params: params
    };

    let route = buildRoute(`api/Project/by-subcategory-id/${subcategoryId}`);

    let result = this.httpClient.get<ProjectPreviewResponse>(route, httpOptions);

    return await lastValueFrom(result);
  }

  async getProjectsPreviewBySkillId(skillId: string, queryParams: ProjectQueryParams) {
    let params = this.setProjectQueryParams(queryParams);

    let httpOptions = {
      params: params
    };

    let route = buildRoute(`api/Project/by-skill-id/${skillId}`);

    let result = this.httpClient.get<ProjectPreviewResponse>(route, httpOptions);

    return await lastValueFrom(result);
  }

  async changeProjectFavoriteStatus(projectId: string, newStatus: boolean) {
    let route = buildRoute(`api/UserFavoriteProject/change-favorite-status/${projectId}`);

    let result = this.httpClient.post(route, newStatus, this.httpOptions);

    return await lastValueFrom(result);
  }

  async postReview(projectId: string, content: string, stars: number) {  
    let request: PostReviewRequest = {
      content: content,
      stars: stars
    }

    let route = buildRoute(`api/Project/review/${projectId}`);

    let result = this.httpClient.post<any>(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async searchProjects(searchText: string, searchThroughAllProjects: boolean, isSkillSubcategoryId: boolean, id: string | undefined) {
    let url = null;
    if (searchThroughAllProjects) {
      url = buildRoute(`api/Project/search/${searchText}`);
    }
    else if (isSkillSubcategoryId) {
      url = buildRoute(`api/Project/search-by-subcategory-id/${searchText}/${id}`);
    }
    else {
      url = buildRoute(`api/Project/search-by-skill-id/${searchText}/${id}`);
    }

    let result = this.httpClient.get<GetProjectPreviewResponse[]>(url);

    return await lastValueFrom(result);
  }

  setProjectQueryParams(queryParams: ProjectQueryParams) {
    let params = new HttpParams();

    if (queryParams.filters) {
      params = this.addFilterQueryParams(queryParams.filters, params);
    }

    params = this.addPageQueryParams(queryParams, params);
    return params;
  }

  private addPageQueryParams(queryParams: ProjectQueryParams, params: HttpParams) {
    if (queryParams.pageSize != null) {
      params = params.append('PageSize', queryParams.pageSize);
    }

    if (queryParams.pageNumber != null) {
      params = params.append('PageNumber', queryParams.pageNumber);
    }
    return params;
  }

  private addFilterQueryParams(filters: FilterProjectQueryParams, params: HttpParams): HttpParams {
    const filterParams = [];

    if (filters.FeaturesId) {
      filters.FeaturesId.forEach(id => {
        filterParams.push(`Filters.FeaturesIds=${id}`);
      });
    }
    if (filters.Rating !== undefined) {
      filterParams.push(`Filters.Rating=${filters.Rating}`);
    }
    if (filters.CountryCodes) {
      filters.CountryCodes.forEach(code => {
        filterParams.push(`Filters.CountryCodes=${code}`);
      });
    }
    if (filters.MinPrice !== undefined) {
      filterParams.push(`Filters.MinPrice=${filters.MinPrice}`);
    }
    if (filters.MaxPrice !== undefined) {
      filterParams.push(`Filters.MaxPrice=${filters.MaxPrice}`);
    }
    if (filters.MinDays !== undefined) {
      filterParams.push(`Filters.MinDays=${filters.MinDays}`);
    }
    if (filters.MaxDays !== undefined) {
      filterParams.push(`Filters.MaxDays=${filters.MaxDays}`);
    }

    const queryString = filterParams.join('&');
    params = new HttpParams({ fromString: queryString });

    return params;
  }
}
