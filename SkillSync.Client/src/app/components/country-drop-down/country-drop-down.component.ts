import { Component, Output, EventEmitter, Input, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Country } from '../../shared/entities/models/country';
import { countriesAndCode } from '../../shared/utils';

@Component({
  selector: 'app-country-drop-down',
  templateUrl: './country-drop-down.component.html',
  styleUrl: './country-drop-down.component.css'
})

export class CountryDropDownComponent {
  countries: any[] | undefined;

  selectedCountry?: Country | null;

  @Input() nationality?: string;
  @Output() selectedCountryEvent = new EventEmitter<Country>();

  ngOnChanges(changes: SimpleChanges) {
    if (changes['nationality'] && this.nationality) {
      this.countries?.find((country) => {
        if (country.nationality === this.nationality) {
          this.selectedCountry = country;
          this.selectedCountryEvent.emit(this.selectedCountry ?? undefined);
          return true;
        }
        return false;
      });
    }
  }

  selectCountryForm = new FormGroup({
    country: new FormControl<Country | null>(null),
  });

  ngOnInit() {
    this.countries = countriesAndCode;
  }

  onChangeSelectCountry(event: any) {
    this.selectedCountry = event.value;

    this.selectedCountryEvent.emit(this.selectedCountry ?? undefined);
  }
}
