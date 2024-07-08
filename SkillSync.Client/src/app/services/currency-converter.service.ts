import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { CurrencyType } from '../shared/enums/currency-type';

@Injectable({
  providedIn: 'root'
})
export class CurrencyConverterService {
  private apiKey = environment.exchangeRateApiKey;
  private apiUrl = `https://v6.exchangerate-api.com/v6/${this.apiKey}/latest`;

  private selectedCurrencySubject = new BehaviorSubject<{ label: string, value: CurrencyType }>({ label: 'USD', value: CurrencyType.USD });
  selectedCurrency$ = this.selectedCurrencySubject.asObservable();

  constructor(private http: HttpClient) { }

  getExchangeRate(baseCurrency: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/${baseCurrency}`).pipe(
      map((data: any) => data.conversion_rates)
    );
  }

  setSelectedCurrency(currency: { label: string, value: CurrencyType }): void {
    this.selectedCurrencySubject.next(currency);
  }

  getSelectedCurrency(): { label: string, value: CurrencyType } {
    return this.selectedCurrencySubject.value;
  }

  getCurrencyOptions(): { label: string, value: CurrencyType }[] {
    return Object.keys(CurrencyType).map(key => ({
      label: key,
      value: CurrencyType[key as keyof typeof CurrencyType]
    }));
  }
}
