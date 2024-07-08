import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private messageService: MessageService) { }

  displaySuccessMessage(message: string, details?: string) {
    this.messageService.add({ severity: 'success', summary: message, detail: details });
  }

  displayErrorMessage(message: string, details?: string) {
    this.messageService.add({ severity: 'error', summary: message, detail: details });
  }

  displayInfoMessage(message: string, details?: string) {
    this.messageService.add({ severity: 'info', summary: message, detail: details });
  }
}
