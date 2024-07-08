import { Component } from '@angular/core';
import { TokenService } from '../../services/token.service';
import { RoleType } from '../../shared/enums/role-type';
import { freelancerOrderStatusToString, orderStatusToString, packageTypeToString, removeWhiteSpaceAndCharactersForRoute, toRoleType } from '../../shared/utils';
import { Order } from '../../shared/entities/models/order';
import { OrderService } from '../../services/order.service';
import { OrderStatus } from '../../shared/enums/order-status';
import { OrderContentPurpose } from '../../shared/enums/order-content-purpose';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { NotificationService } from '../../services/notification.service';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../../shared/enums/currency-type';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrl: './order-page.component.scss',
  providers: [ConfirmationService]
})
export class OrderPageComponent {
  currentUserRole?: RoleType;
  skillScoutRole = RoleType.SkillScout;
  completedOrderStatus = OrderStatus.Completed;

  orderId?: string;
  order?: Order;
  currentOrderStatus?: { name: string, status: OrderStatus };

  previewOrderContentPurpose: OrderContentPurpose = OrderContentPurpose.Preview;
  finalProductOrderContentPurpose: OrderContentPurpose = OrderContentPurpose.FinalProduct;

  orderStatuses?: { name: string, status: OrderStatus }[];
  currencyType: { label: string, value: CurrencyType } = { label: 'USD', value: CurrencyType.USD };

  displaySaveNewStatusDialog: boolean = false;
  displayOrderStatusAsText: boolean = false;
  displayReviewDialog: boolean = false;

  isFinalProductsTabPanelContentDisabled: boolean = false;
  editModeActive: boolean = true;

  shouldDisplayPayProductsDialog = false;
  activeTabIndex: number = 0;
  isOrderLate: boolean = false;

  pendingOrderStatus = OrderStatus.Pending;
  activeOrderStatus = OrderStatus.Active;
  deliveredOrderStatus = OrderStatus.Delivered;
  cancelledOrderStatus = OrderStatus.Cancelled;

  constructor
    (
      private orderService: OrderService,
      private tokenService: TokenService,
      private notificationService: NotificationService,
      private confirmationService: ConfirmationService,
      private currencyConverterService: CurrencyConverterService,
      private router: Router
    ) { }

  async ngOnInit() {
    this.currencyConverterService.selectedCurrency$.subscribe(currency => {
      this.currencyType = currency;
    });

    this.currentUserRole = toRoleType(this.tokenService.getRole() ?? '')!;

    this.orderId = history.state.orderId;

    if (this.orderId) {
      this.order = await this.orderService.getOrderById(this.orderId);

      if (this.currentUserRole == RoleType.SkillScout) {
        this.editModeActive = false;
        this.displayOrderStatusAsText = true;

        this.isFinalProductsTabPanelContentDisabled = true;

        if (this.order?.status == OrderStatus.Delivered || this.order?.status == OrderStatus.Completed) {
          this.isFinalProductsTabPanelContentDisabled = false;
        }

        return;
      }

      if (this.order.status == OrderStatus.Delivered || this.order.status == OrderStatus.Completed || this.order.status == OrderStatus.Cancelled) {
        this.editModeActive = false;
        this.displayOrderStatusAsText = true;
      }

      this.orderStatuses = [];
      let pendingOrderStatus = { name: this.freelancerOrderStatusToString(OrderStatus.Pending), status: OrderStatus.Pending };
      if (this.order?.status == OrderStatus.Pending) {
        this.orderStatuses = this.orderStatuses.concat(pendingOrderStatus);
      }

      this.isOrderLate = this.order?.untilTo && new Date(this.order.untilTo) < new Date();

      this.orderStatuses = this.orderStatuses.concat(
        { name: this.freelancerOrderStatusToString(OrderStatus.Active), status: OrderStatus.Active },
        { name: this.freelancerOrderStatusToString(OrderStatus.Delivered), status: OrderStatus.Delivered },
        { name: this.freelancerOrderStatusToString(OrderStatus.Cancelled), status: OrderStatus.Cancelled }
      );

      this.currentOrderStatus = this.orderStatuses.find(status => status.status == this.order?.status);
    }
  }

  changeStatusConfirmation(event: Event) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: 'Are you sure that you want to change project status?',
      header: 'Change Project Status',
      icon: 'pi pi-exclamation-triangle',
      acceptIcon: "none",
      rejectIcon: "none",
      acceptButtonStyleClass: "p-button-text btn-primary rounded ms-2",
      rejectButtonStyleClass: "p-button-text btn-secondary rounded",
      accept: async () => {
        if (this.order) {
          await this.orderService.updateOrderStatus(this.order?.id, this.currentOrderStatus!.status);
          this.notificationService.displaySuccessMessage("Order status has been changed successfully");
          this.displaySaveNewStatusDialog = false;
          this.order.status = this.currentOrderStatus!.status;
          if (this.currentOrderStatus?.status == OrderStatus.Delivered || this.currentOrderStatus?.status == OrderStatus.Cancelled) {
            this.displayOrderStatusAsText = true;
            this.order.completedAt = new Date();
          }
        }
      },
      reject: () => {
        this.notificationService.displayErrorMessage("Changing order status has been canceled");
      }
    });
  }

  returnToPreviewTab() {
    this.shouldDisplayPayProductsDialog = false;
    this.activeTabIndex = 0;
  }

  goToService() {
    let projectTitle = removeWhiteSpaceAndCharactersForRoute(this.order?.projectTitle ?? '');
    if (this.currentUserRole == RoleType.Freelancer) {
      let yourName = this.tokenService.getUsername() ?? '';
      let freelancerName = removeWhiteSpaceAndCharactersForRoute(yourName);
      this.router.navigate([`/project/${freelancerName}/${projectTitle}`], { state: { projectId: this.order?.projectId } });
    }
    else {
      this.router.navigate([`/project/${projectTitle}`], { state: { projectId: this.order?.projectId } });
    }
  }

  orderStatusChanged(event: any) {
    this.displaySaveNewStatusDialog = true;
  }

  async onSaveNewStatus(event: any) {
    this.changeStatusConfirmation(event);
  }

  onCancelNewStatus() {
    this.displaySaveNewStatusDialog = false;
  }

  navigateToProfile() {
    let freelancerName = this.removeWhiteSpaceAndCharactersForRoute(this.order?.freelancerName ?? '');
    this.router.navigate(['/freelancer', freelancerName], { state: { freelancerId: this.order?.freelancerId } });
  }

  async checkOrderStatusToActive() {
    if (this.order?.id) {
      this.order.status = OrderStatus.Active;
      this.orderStatuses = this.orderStatuses?.filter(orderStatus => orderStatus.status != OrderStatus.Pending);
      this.currentOrderStatus = this.orderStatuses?.filter(orderStatus => orderStatus.status == this.order?.status)[0];
      this.orderService.updateOrderStatus(this.order?.id, OrderStatus.Active);
    }
  }

  async transactionCompleted(status: boolean) {
    if (status) {
      if (this.order) {
        await this.orderService.updateOrderStatus(this.order?.id, OrderStatus.Completed);
        this.shouldDisplayPayProductsDialog = false;
        this.order.status = OrderStatus.Completed;
        this.order.completedAt = new Date();
        this.notificationService.displaySuccessMessage("Payment succeed");
        this.displayReviewDialog = true;
      }
    }
    else {
      this.returnToPreviewTab();
    }
  }

  closeReviewDialog() {
    this.displayReviewDialog = false;
  }

  tabpanelChanged(index: number) {
    if (index == 1 && this.order?.status == OrderStatus.Delivered && this.currentUserRole == this.skillScoutRole) {
      this.shouldDisplayPayProductsDialog = true;
    }
  }

  freelancerOrderStatusToString = freelancerOrderStatusToString;
  orderStatusToString = orderStatusToString;
  packageTypeToString = packageTypeToString;
  removeWhiteSpaceAndCharactersForRoute = removeWhiteSpaceAndCharactersForRoute;
}