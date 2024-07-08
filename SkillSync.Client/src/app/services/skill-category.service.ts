import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SkillCategory } from '../shared/entities/models/skill-category';
import { lastValueFrom } from 'rxjs';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { Feature } from '../shared/entities/models/feature';
import { FrequentlyAskedQuestion } from '../shared/entities/models/frequently-asked-question';

@Injectable({
  providedIn: 'root'
})
export class SkillCategoryService {
  skillCategories: SkillCategory[] = [];

  constructor(private httpClient: HttpClient) { }

  private readonly httpOptions = jsonHttpOptions;

  async getAllSkillCategories(): Promise<SkillCategory[]> {
    if (this.skillCategories.length == 0) {
      let route = buildRoute("api/SkillCategory");

      let result = this.httpClient.get<SkillCategory[]>(route, this.httpOptions);

      let response = await lastValueFrom(result);

      this.skillCategories = response;
    }

    return this.skillCategories;
  }

  async getFeaturesBySkillSubcategoryId(id: string) {
    let route = buildRoute(`api/SkillSubcategory/feature-options/${id}`);

    let result = this.httpClient.get<Feature[]>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getFrequentlyAskedQuestions(id: string) {
    let route = buildRoute(`api/SkillCategory/frequently-asked-questions/${id}`);

    let result = this.httpClient.get<FrequentlyAskedQuestion[]>(route, this.httpOptions);

    return await lastValueFrom(result);
  }
}