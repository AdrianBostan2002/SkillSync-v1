import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { buildRoute } from '../shared/utils';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderContentService {

  constructor(private httpClient: HttpClient, private notificationService: NotificationService) { }

  async getOrderContentFileById(id: string) {
    let token = localStorage.getItem("token");

    if (token == null || token == "") {
      this.notificationService.displayErrorMessage("Token is not set");
    }

    let httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      }),
      responseType: 'blob' as 'json'
    };

    let route = buildRoute(`api/OrderContent/get-content-file/${id}`);

    let result = this.httpClient.get<Blob>(route, httpOptions);

    return await lastValueFrom(result);
  }
}
