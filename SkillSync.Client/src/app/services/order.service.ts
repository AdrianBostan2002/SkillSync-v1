import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { PlaceOrderRequest } from '../shared/entities/requests/place-order-request';
import { buildRoute, jsonHttpOptions } from '../shared/utils';
import { lastValueFrom } from 'rxjs';
import { OrderStatus } from '../shared/enums/order-status';
import { OrderPreviewDto } from '../shared/entities/responses/order-preview-dto';
import { Order } from '../shared/entities/models/order';
import { OrderContentFileDto } from '../shared/entities/requests/order-content-file-dto';
import { ModifiedDescriptionDto } from '../shared/entities/requests/modified-description-dto';
import { OrderContentPurpose } from '../shared/enums/order-content-purpose';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient: HttpClient, private notificationService: NotificationService) { }

  private readonly httpOptions = jsonHttpOptions;

  async placeOrder(request: PlaceOrderRequest) {
    let route = buildRoute(`api/Order`);

    let result = this.httpClient.post(route, request, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getOrdersByStatus(status: OrderStatus) {
    let route = buildRoute(`api/Order/by-status/${status}`);

    let result = this.httpClient.get<OrderPreviewDto[]>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async getOrderById(id: string) {
    let route = buildRoute(`api/Order/${id}`);

    let result = this.httpClient.get<Order>(route, this.httpOptions);

    return await lastValueFrom(result);
  }

  async updateOrderStatus(orderId: string, status: OrderStatus) {
    let route = buildRoute(`api/Order/${orderId}/status`);

    let result = this.httpClient.patch(route, status, this.httpOptions);

    return await lastValueFrom(result);
  }

  async patchOrderContentMedia
    (
      uploadedPictures: OrderContentFileDto[], uploadedVideos: OrderContentFileDto[],
      uploadedDocuments: OrderContentFileDto[], uploadedAudios: OrderContentFileDto[],
      modifiedDescriptions: ModifiedDescriptionDto[], 
      uploadedNotes: string,
      deletedMedia: string[],
      orderId: string, orderContentPurpose: OrderContentPurpose
    ) {
    let token = localStorage.getItem("token");

    if (token == null || token == "") {
      this.notificationService.displayErrorMessage("Token is not set");
    }

    const formData = new FormData();

    uploadedPictures.forEach((picture, index) => {
      if (picture.file) {
        formData.append(`uploadedPictures[${index}].file`, picture?.file, picture.file.name);
      }
      formData.append(`uploadedPictures[${index}].description`, picture.description ?? '');
    });

    uploadedVideos.forEach((video, index) => {
      if (video.file) {
        formData.append(`uploadedVideos[${index}].file`, video.file, video.file.name);
      }
      formData.append(`uploadedVideos[${index}].description`, video.description ?? '');
    });

    uploadedDocuments.forEach((document, index) => {
      if (document.file) {
        formData.append(`uploadedDocuments[${index}].file`, document.file, document.file.name);
      }
      formData.append(`uploadedDocuments[${index}].description`, document.description ?? '');
    });

    uploadedAudios.forEach((audio, index) => {
      if (audio.file) {
        formData.append(`uploadedAudios[${index}].file`, audio.file, audio.file.name);
      }
      formData.append(`uploadedAudios[${index}].description`, audio.description ?? '');
    });

    modifiedDescriptions.forEach((modifiedDescription, index) => {
      formData.append(`modifiedDescriptions[${index}].orderContentId`, modifiedDescription.orderContentId);
      formData.append(`modifiedDescriptions[${index}].description`, modifiedDescription.description ?? '');
    });

    if (uploadedNotes!='') {
      formData.append('modifiedNotes', uploadedNotes);
    }

    deletedMedia.forEach((id, index) => {
      formData.append(`deletedOrderContents[${index}]`, id);
    });

    let route = buildRoute(`api/Order/media-content/${orderId}/${orderContentPurpose}`);

    let result = this.httpClient.patch(route, formData);

    return await lastValueFrom(result)
  }
}
