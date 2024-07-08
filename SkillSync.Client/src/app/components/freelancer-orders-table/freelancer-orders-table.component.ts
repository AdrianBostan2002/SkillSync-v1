import { Component, Input } from '@angular/core';
import { OrderPreviewDto } from '../../shared/entities/responses/order-preview-dto';
import { OrderStatus } from '../../shared/enums/order-status';
import { orderStatusToString, removeWhiteSpaceAndCharactersForRoute, toRoleType } from '../../shared/utils';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { RoleType } from '../../shared/enums/role-type';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../../shared/enums/currency-type';

@Component({
  selector: 'app-freelancer-orders-table',
  templateUrl: './freelancer-orders-table.component.html',
  styleUrl: './freelancer-orders-table.component.css'
})
export class FreelancerOrdersTableComponent {
  @Input() orders?: OrderPreviewDto[];
  @Input() status?: OrderStatus;

  currentUserRole?: RoleType | null;
  freelancerRole = RoleType.Freelancer;

  deliveredStatus: OrderStatus = OrderStatus.Delivered;
  completedStatus: OrderStatus = OrderStatus.Completed;
  cancelledStatus: OrderStatus = OrderStatus.Cancelled;

  currencyType: { label: string, value: CurrencyType } = { label: 'USD', value: CurrencyType.USD };

  constructor(
    private router: Router,
    private tokenService: TokenService,
    private currencyConverterService: CurrencyConverterService
  ) { }

  ngOnInit() {
    this.currencyConverterService.selectedCurrency$.subscribe(currency => {
      this.currencyType = currency;
    });

    this.currentUserRole = toRoleType(this.tokenService.getRole() ?? '');
  }

  onOrderSelected(order: OrderPreviewDto) {
    let name = this.tokenService.getUsername();
    let freelancerName = removeWhiteSpaceAndCharactersForRoute(name ?? '');
    let projectTitle = removeWhiteSpaceAndCharactersForRoute(order.projectTitle);

    this.router.navigate([`/order/${freelancerName}/${projectTitle}`], { state: { orderId: order.id } });
  }

  statusToString = orderStatusToString;
}