import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Feature } from '../../shared/entities/models/feature';
import { countriesAndCode } from '../../shared/utils';
import { SkillCategoryService } from '../../services/skill-category.service';
import { FeatureInputType } from '../../shared/enums/feature-input-type';
import { FilterProjectQueryParams } from '../../shared/entities/requests/query-params/filter-project-query-params';
import { ProjectQueryParams } from '../../shared/entities/requests/query-params/project-query-params';

@Component({
  selector: 'app-project-filters-bar',
  templateUrl: './project-filters-bar.component.html',
  styleUrl: './project-filters-bar.component.css'
})
export class ProjectFiltersBarComponent {
  @Input() skillId?: string;
  @Input() skillsubcategoryId?: string;
  @Output() filterProjectsPreviewEvent = new EventEmitter<ProjectQueryParams>();

  overlayOpens: boolean[] = [false, false, false, false];

  features: { feature: Feature, isSelected: boolean }[] = [];
  ratings: number[] = [];
  sellerLocations: { name: string, code: string, isSelected: boolean }[] = [];
  priceRanges: { minPrice: number, maxPrice: number, label: string }[] = [];
  deliveryTimes: { min: number, max: number, label: string, isSelected: boolean }[] = [];

  selectedRating?: number;
  selectedPriceIndex?: number;
  selectedDeliveryTimeIndex?: number;

  rangeValues: number[] = [1, 100000];

  private maxServerAcceptableNumber: number = 1000000;

  constructor(private skillCategoryService: SkillCategoryService, private skillSubcategoryService: SkillCategoryService) { }

  countriesIncrementor = 20;

  onLoadMoreCountries() {
    let sellerLocationslenght = this.sellerLocations.length;
    let nextCountries = countriesAndCode.slice(sellerLocationslenght + 1, sellerLocationslenght + 1 + this.countriesIncrementor);

    nextCountries = nextCountries.filter(country =>
      country.code != 'RO' && country.code != 'US' && country.code != 'GB' && country.code != 'CA');

    this.sellerLocations = this.sellerLocations.concat(nextCountries.map(country => {
      return { name: country.name, code: country.code, isSelected: false };
    }));
  }

  async onFeaturesShow() {
    if (!this.skillsubcategoryId && this.skillId) {
      let skillsCategories = await this.skillCategoryService.getAllSkillCategories();

      let found = false;
      for (const skillCategory of skillsCategories) {
        if (found) break;
        for (const skillSubcategory of skillCategory.skillSubcategories) {
          if (found) break;
          for (const skill of skillSubcategory.skills) {
            if (skill.id == this.skillId) {
              this.skillsubcategoryId = skillSubcategory.id;
              found = true;
              break;
            }
          }
        }
      }
    }

    if (this.skillsubcategoryId && this.features.length == 0) {
      let features = await this.skillSubcategoryService.getFeaturesBySkillSubcategoryId(this.skillsubcategoryId);

      features = features.filter(feature => feature.inputType == FeatureInputType.Checkbox);

      this.features = features.map(feature => {
        return { feature: feature, isSelected: false };
      });
    }

    this.overlayOpens[0] = true;
  }

  onSellerDetailsShow() {
    if (this.ratings.length == 0 && this.sellerLocations.length == 0) {
      this.ratings = this.ratings.concat([1, 2, 3, 4, 5]);

      let specificCountries = countriesAndCode.filter(country =>
        country.code == 'RO' || country.code == 'US' || country.code == 'GB' || country.code == 'CA');

      this.sellerLocations = specificCountries.map(country => {
        return { name: country.name, code: country.code, isSelected: false };
      });
    }
    this.overlayOpens[1] = true;
  }

  onBuget() {
    if (this.priceRanges.length == 0) {
      this.priceRanges = this.priceRanges.concat({
        minPrice: 1,
        maxPrice: 100,
        label: 'Price under 100$',
      },
        {
          minPrice: 101,
          maxPrice: 300,
          label: 'Mid range 101$-300$',
        },
        {
          minPrice: 301,
          maxPrice: 1000000,
          label: 'High end 300$+',
        },
        {
          minPrice: 1,
          maxPrice: this.maxServerAcceptableNumber,
          label: 'Custom',
        }
      );
    }

    this.overlayOpens[2] = true;
  }

  onDeliveryTime() {
    if (this.deliveryTimes.length == 0) {
      this.deliveryTimes = this.deliveryTimes.concat([
        {
          min: 1,
          max: 1,
          label: 'Expres 24h',
          isSelected: false
        },
        {
          min: 1,
          max: 3,
          label: 'Up to 3 days',
          isSelected: false
        },
        {
          min: 5,
          max: this.maxServerAcceptableNumber,
          label: 'Up to 5 days',
          isSelected: false
        },
      ]);
    }

    this.overlayOpens[3] = true;
  }

  async onApplyFilters() {
    if (this.skillsubcategoryId) {
      const filtersParams: FilterProjectQueryParams = {
        Rating: this.selectedRating,
        MinPrice: this.selectedPriceIndex == undefined ? undefined : this.priceRanges?.[this.selectedPriceIndex]?.label !== 'Custom' ? this.priceRanges?.[this.selectedPriceIndex]?.minPrice : this.rangeValues[0],
        MaxPrice: this.selectedPriceIndex == undefined ? undefined : this.priceRanges?.[this.selectedPriceIndex]?.label !== 'Custom' ? this.priceRanges?.[this.selectedPriceIndex]?.maxPrice : this.rangeValues[1],
        MinDays: this.selectedDeliveryTimeIndex == undefined ? undefined : this.deliveryTimes?.[this.selectedDeliveryTimeIndex]?.min,
        MaxDays: this.selectedDeliveryTimeIndex == undefined ? undefined : this.deliveryTimes?.[this.selectedDeliveryTimeIndex]?.max,
        FeaturesId: this.features.filter(feature => feature.isSelected).map(feature => feature.feature.id),
        CountryCodes: this.sellerLocations.filter(location => location.isSelected).map(location => location.code)
      };

      const queryParams: ProjectQueryParams = {
        filters: filtersParams,
      }

      this.filterProjectsPreviewEvent.emit(queryParams);
    }
  }

  deleteAllAppliedFilters() {
    this.selectedRating = undefined;
    this.selectedPriceIndex = undefined;

    this.sellerLocations.forEach(sellerLocation => {
      sellerLocation.isSelected = false;
    });

    this.deliveryTimes.forEach(deliveryTime => {
      deliveryTime.isSelected = false;
    });
    this.selectedDeliveryTimeIndex = undefined;

    this.features.forEach(feature => feature.isSelected = false);
    this.rangeValues[0] = 1;
    this.rangeValues[1] = 100000;

    this.onApplyFilters();
  }
}