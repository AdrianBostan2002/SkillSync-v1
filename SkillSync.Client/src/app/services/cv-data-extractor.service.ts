import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResumeDataDto } from '../shared/entities/responses/resume-data-dto';
import { lastValueFrom } from 'rxjs';
import { buildRoute } from '../shared/utils';

@Injectable({
  providedIn: 'root'
})
export class CvDataExtractorService {

  constructor(private httpClient: HttpClient) { }

  async extractCvData(cv: File) {
    const formData = new FormData();
    formData.append('resume', cv, cv.name);

    let route = buildRoute("api/CVDataExtractor");

    let result = this.httpClient.post<ResumeDataDto>(route, formData);

    return await lastValueFrom(result);
  }
}
