import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../enums/currency-type';
import { CurrencyPipe } from '@angular/common';

@Pipe({
  name: 'currencyConverter'
})
@Injectable({
  providedIn: 'root'
})
export class CurrencyConverterPipe implements PipeTransform {

  exchangeRates: any = {};
  selectedCurrency: { label: string, value: CurrencyType } = { label: "USD", value: CurrencyType.USD }

  constructor(private currencyConverterService: CurrencyConverterService, private currencyPipe: CurrencyPipe) {
    this.loadExchangeRates();
    this.currencyConverterService.selectedCurrency$.subscribe(currency => {
      this.selectedCurrency = currency;
    });
  }

  loadExchangeRates() {
    this.currencyConverterService.getExchangeRate(CurrencyType.USD).subscribe(rates => {
      this.exchangeRates = rates;
    });
  }

  transform(value: number, currency: { label: string, value: CurrencyType } = this.selectedCurrency): string | null {
    const rate = this.exchangeRates[currency.value];
    if (!rate || currency.value === CurrencyType.USD) {
      return this.currencyPipe.transform(value, 'USD', 'symbol', '1.2-2');
    }
    const convertedValue = value * rate;
    if (convertedValue !== null && convertedValue !== undefined) {
      return this.currencyPipe.transform(convertedValue, currency.value, 'symbol', '1.2-2') || '';
    } else {
      return '';
    }
  }
}
