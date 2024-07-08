import { Component, EventEmitter, Input, Output, } from '@angular/core';

declare var paypal: any;

@Component({
  selector: 'app-paypal-button',
  templateUrl: './paypal-button.component.html',
  styleUrl: './paypal-button.component.css'
})
export class PaypalButtonComponent {
  @Input() amount?: number = 0.01;
  @Output() wasTransactionCompletedSuccessfully = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
    paypal.Buttons({
      style: {
        layout: 'vertical',
        color: 'blue',
        shape: 'pill',
        label: 'pay'
      },
      createOrder: (_data: any, actions: {
        order: {
          create: (arg0: {
            purchase_units: {
              amount: {
                value: string;
              };
            }[];
          }) => any;
        };
      }) => {
        return actions.order.create({
          purchase_units: [{
            amount: {
              value: this.amount?.toString() ?? '0.01'  
            }
          }]
        });
      },
      onApprove: (data: any, actions: { order: { capture: () => Promise<any>; }; }) => {
        return actions.order.capture().then((details: { payer: { name: { given_name: string; }; }; }) => {
          this.wasTransactionCompletedSuccessfully.emit(true);
        });
      },
      oncancel: (data: any) => {
        this.wasTransactionCompletedSuccessfully.emit(false);
      }
    }).render('#paypal-button-container');
  }
}
