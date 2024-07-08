import { Component } from '@angular/core';
import { OrderPreviewDto } from '../../shared/entities/responses/order-preview-dto';
import { OrderService } from '../../services/order.service';
import { OrderStatus } from '../../shared/enums/order-status';
import { orderStatusToString } from '../../shared/utils';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrl: './orders-page.component.css'
})
export class OrdersPageComponent {
  pendingOrders: OrderPreviewDto[] = [];
  activeOrders: OrderPreviewDto[] = [];
  deliveredOrders: OrderPreviewDto[] = [];
  completedOrders: OrderPreviewDto[] = [];
  lateOrders: OrderPreviewDto[] = [];
  cancelledOrders: OrderPreviewDto[] = [];

  pendingStatus: OrderStatus = OrderStatus.Pending;
  activeStatus: OrderStatus = OrderStatus.Active;
  deliveredStatus: OrderStatus = OrderStatus.Delivered;
  completedStatus: OrderStatus = OrderStatus.Completed;
  cancelledStatus: OrderStatus = OrderStatus.Cancelled;

  ordersWithTheirStatus?: { orders: OrderPreviewDto[], status: OrderStatus }[] = [];

  constructor(private orderService: OrderService) { }

  async ngOnInit() {
    this.ordersWithTheirStatus = [
      { orders: this.pendingOrders, status: this.pendingStatus },
      { orders: this.activeOrders, status: this.activeStatus },
      { orders: this.deliveredOrders, status: this.deliveredStatus },
      { orders: this.completedOrders, status: this.completedStatus },
      { orders: this.cancelledOrders, status: this.cancelledStatus }
    ];

    this.pendingOrders = await this.orderService.getOrdersByStatus(this.pendingStatus);
    this.ordersWithTheirStatus[0].orders = this.pendingOrders;
  }

  async retrieveOrders(index: number) {
    if (this.ordersWithTheirStatus && this.ordersWithTheirStatus[index].orders.length == 0) {
      this.ordersWithTheirStatus[index].orders = await this.orderService.getOrdersByStatus(this.ordersWithTheirStatus[index].status);
    }
  }

  statusToString = orderStatusToString;
}