import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { GetProjectResponse } from '../../shared/entities/responses/get-project-response';
import { FormBuilder, Validators } from '@angular/forms';
import { PackageType } from '../../shared/enums/packages';
import { PlaceOrderRequest } from '../../shared/entities/requests/place-order-request';
import { DatePipe } from '@angular/common';
import { ConfirmationService } from 'primeng/api';
import { NotificationService } from '../../services/notification.service';
import { OrderService } from '../../services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-place-order-dialog',
  templateUrl: './place-order-dialog.component.html',
  styleUrl: './place-order-dialog.component.css',
  providers: [ConfirmationService]
})
export class PlaceOrderDialogComponent {
  @Input() project?: GetProjectResponse;
  @Input() isDialogVisible: boolean = false;
  @Input() packageType?: PackageType;
  @Output() closeDialogEvent = new EventEmitter<void>();

  acceptTermsConditionsMessage: string = "By checking this box, I confirm that I have read the document and agree to abide by its terms and conditions.";

  constructor
  (
    private confirmationService: ConfirmationService, 
    private notificationService: NotificationService,
    private orderService: OrderService, 
    private router: Router,
    private formBuilder: FormBuilder, 
    private datepipe: DatePipe
  ) { }

  placeOrderForm = this.formBuilder.group({
    hasAcceptedTermsConditions: [false, Validators.requiredTrue]
  });

  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key === 'Escape' && this.isDialogVisible) {
      this.close();
      event.preventDefault();
    }
  }

  createPlaceOrderRequest() {
    let createdAt = this.datepipe.transform(new Date(), 'yyyy-MM-ddTHH:mm:ss') as string;
    let untilTo = this.datepipe.transform(new Date(new Date().getTime() + this.getPackageDeliveryTime() * 24 * 60 * 60 * 1000), 'yyyy-MM-ddTHH:mm:ss') as string;

    let request: PlaceOrderRequest = {
      projectID: this.project?.id ?? '',
      packageType: this.packageType ?? this.packageType ?? PackageType.Basic,
      createdAt: createdAt,
      untilTo: untilTo
    }

    return request;
  }

  placeOrderConfirmation(event: Event) {
    this.confirmationService.confirm({
        target: event.target as EventTarget,
        message: 'Are you sure that you want to proceed?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        acceptIcon:"none",
        rejectIcon:"none",
        acceptButtonStyleClass:"p-button-text btn-primary rounded ms-2",
        rejectButtonStyleClass:"p-button-text btn-secondary rounded",
        accept: async () => {
            let request = this.createPlaceOrderRequest();

            let orderId = await this.orderService.placeOrder(request);

            this.notificationService.displaySuccessMessage("Order has been placed successfully");
            this.closeDialogEvent.emit();
            this.router.navigate(['/landing-page']);
        },
        reject: () => {
          this.notificationService.displayErrorMessage("Order placing has been canceled");
        }
    });
}

  getPackageDeliveryTime(){
    let feature = this.project?.features.filter(feature=> feature.name?.toLowerCase() == "delivery time");
    if(feature){
      if(this.packageType == PackageType.Basic){
        return feature[0].basicSelectedValue as unknown as number;
      }
      if(this.packageType == PackageType.Standard){
        return feature[0].standardSelectedValue as unknown as number;
      }
      if(this.packageType == PackageType.Premium){
        return feature[0].premiumSelectedValue as unknown as number;
      }
    }
    return 1;
  }

  close() {
    this.closeDialogEvent.emit();
  }
}
