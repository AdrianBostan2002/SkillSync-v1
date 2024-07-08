import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SkillCategoryService } from '../../services/skill-category.service';
import { Feature } from '../../shared/entities/models/feature';
import { FeatureInputType } from '../../shared/enums/feature-input-type';
import { DropdownOption } from '../../shared/entities/models/dropdown-option';
import { range } from '../../shared/utils';
import { CheckBoxOption } from '../../shared/entities/models/checkbox-option';
import { TextAreaOption } from '../../shared/entities/models/textarea-option';
import { ProjectFeature } from '../../shared/entities/models/project-option';
import { FeatureOptionBase } from '../../shared/entities/models/feature-option-base';
import { ProjectService } from '../../services/project.service';
import { GetProjectPricingDto } from '../../shared/entities/requests/add-project-steps/get-project-pricing-dto';
import { AddOrUpdateProjectPricingDto } from '../../shared/entities/requests/add-project-steps/add-or-update-project-pricing-dto';

@Component({
  selector: 'app-post-project-pricing',
  templateUrl: './post-project-pricing.component.html',
  styleUrl: './post-project-pricing.component.scss'
})
export class PostProjectPricingComponent {
  checkBoxOptions: CheckBoxOption[] = [];
  dropdownOptions?: DropdownOption[];
  textAreaOptions?: TextAreaOption[];
  skillSubcategoryId: string = "";
  projectId?: string;

  features?: GetProjectPricingDto;

  featureOptions: Feature[] = [];

  shouldDisplayErrorMessage: boolean = false;
  hasPackages?: boolean;
  errorMessage: string = "Please complete required fields!";

  packageTitleIndex?: number;
  packageDescriptionIndex?: number;
  priceIndex?: number;

  constructor
    (
      private router: Router,
      private route: ActivatedRoute,
      private skillCategoryService: SkillCategoryService,
      private projectService: ProjectService
    ) { }

  async ngOnInit() {
    this.skillSubcategoryId = this.route.snapshot.params['id'];
    this.featureOptions = await this.skillCategoryService.getFeaturesBySkillSubcategoryId(this.skillSubcategoryId);

    this.projectId = history.state.projectId;
    if (this.projectId) {
      this.features = await this.projectService.getProjectPricing(this.projectId);
      this.hasPackages = this.features.hasPackages;
    }

    this.mapOptions();
  }

  mapOptions() {
    this.checkBoxOptions = [];
    this.dropdownOptions = [];
    this.textAreaOptions = [];

    this.featureOptions.forEach((option) => {
      if (option.inputType == FeatureInputType.Checkbox) {
        let basicSelectedValue = false;
        let standardSelectedValue = false;
        let premiumSelectedValue = false;

        if (this.features?.features && this.features?.features[option.id]) {
          basicSelectedValue = this.features.features[option.id].basicSelectedValue === 'true';
          if (this.features.hasPackages) {
            standardSelectedValue = this.features.features[option.id].standardSelectedValue === 'true';
            premiumSelectedValue = this.features.features[option.id].premiumSelectedValue === 'true';
          }
        }

        let checkboxOption: CheckBoxOption = { featureId: option.id, name: option.name, basicSelectedValue: basicSelectedValue, standardSelectedValue: standardSelectedValue, premiumSelectedValue: premiumSelectedValue, defaultValue: false };
        this.checkBoxOptions?.push(checkboxOption);
      }
      else if (option.inputType == FeatureInputType.Dropdown) {
        if (option.dropdownOption) {
          option.dropdownOption.name = option.name;
          option.dropdownOption.featureId = option.id;
          option.dropdownOption.basicSelectedValue = 0;
          option.dropdownOption.standardSelectedValue = 0;
          option.dropdownOption.premiumSelectedValue = 0;
          option.dropdownOption.defaultValue = 0;

          if (this.features?.features != undefined && this.features?.features[option.id]) {
            option.dropdownOption.basicSelectedValue = parseInt(this.features.features[option.id].basicSelectedValue);
            if (this.features.hasPackages) {
              option.dropdownOption.standardSelectedValue = parseInt(this.features.features[option.id].standardSelectedValue ?? '0');
              option.dropdownOption.premiumSelectedValue = parseInt(this.features.features[option.id].premiumSelectedValue ?? '0');
            }
          }
          option.dropdownOption.values = this.generateDropdownValues(option.dropdownOption);
          this.dropdownOptions?.push(option.dropdownOption);
        }
      }
      else if (option.inputType == FeatureInputType.TextArea) {
        let basicSelectedValue = "";
        let standardSelectedValue = "";
        let premiumSelectedValue = "";

        if (this.features?.features && this.features?.features[option.id]) {
          basicSelectedValue = this.features.features[option.id].basicSelectedValue;
          if (this.features.hasPackages) {
            standardSelectedValue = this.features.features[option.id].standardSelectedValue;
            premiumSelectedValue = this.features.features[option.id].premiumSelectedValue;
          }
        }

        let textAreaOption: TextAreaOption = { featureId: option.id, name: option.name, basicSelectedValue: basicSelectedValue, premiumSelectedValue: premiumSelectedValue, standardSelectedValue: standardSelectedValue, defaultValue: "" };
        this.textAreaOptions?.push(textAreaOption);

        if (this.textAreaOptions) {
          let index = this.textAreaOptions.length - 1 >= 0 ? this.textAreaOptions.length - 1 : 0;
          if (option.name == "Package name") {
            this.packageTitleIndex = index;
          }
          else if (option.name == "Package description") {
            this.packageDescriptionIndex = index;
          }
          else if (option.name == "Price") {
            this.priceIndex = index;
          }
        }
      }
    });
  }

  generateDropdownValues(dropdownOption: DropdownOption): number[] {
    const values: number[] = [];
    for (let i = dropdownOption.lowerInterval; i <= dropdownOption.upperInterval; i += dropdownOption.incrementValue) {
      values.push(i);
    }
    return values;
  }

  private createProjectFeature<T>(option: FeatureOptionBase<T>): ProjectFeature {
    let standardValue = `${option.standardSelectedValue ?? null}`;
    let premiumValue = `${option.premiumSelectedValue ?? null}`;
    if (!this.hasPackages) {
      standardValue = "";
      premiumValue = "";
    }
    let projectFeature: ProjectFeature = {
      featureId: option.featureId ?? "", basicSelectedValue: `${option.basicSelectedValue ?? null}`,
      premiumSelectedValue: premiumValue, standardSelectedValue: standardValue
    }

    return projectFeature;
  }

  private addOptionsToProjectFeatures<T>(options: FeatureOptionBase<T>[], projectFeatures: ProjectFeature[]) {
    let wasAnyProjectFeatureModified = false;
    let shouldDisplayErrorMessage = false;
    for (const option of options) {
      if (typeof option.basicSelectedValue !== 'boolean' &&
        (option.basicSelectedValue === option.defaultValue ||
          (this.hasPackages && (option.standardSelectedValue === option.defaultValue || option.premiumSelectedValue === option.defaultValue)))) {
        return [wasAnyProjectFeatureModified, true];
      }
      if (option.featureId && this.features?.features[option.featureId]) {
        let featureHasChanged = false;
        let previousBasicSelectedValue = (this.features.features[option.featureId].basicSelectedValue) as string;
        let currentBasicSelectedValue = String(option.basicSelectedValue);
        if (previousBasicSelectedValue !== currentBasicSelectedValue) {
          featureHasChanged = true;
        }
        if (this.hasPackages || this.features.hasPackages) {
          let previousStandardSelectedValue = this.features.features[option.featureId].standardSelectedValue as T;
          let previousPremiumSelectedValue = this.features.features[option.featureId].premiumSelectedValue as T;
          let currentStandardSelectedValue = String(option.standardSelectedValue);
          let currentPremiumSelectedValue = String(option.premiumSelectedValue);
          if (previousStandardSelectedValue !== currentStandardSelectedValue || previousPremiumSelectedValue !== currentPremiumSelectedValue) {
            featureHasChanged = true;
          }
        }
        if (featureHasChanged) {
          wasAnyProjectFeatureModified = true;
        }
        else {
          continue;
        }
      }

      let projectFeature = this.createProjectFeature(option);
      if (projectFeature != null) {
        projectFeatures.push(projectFeature);
        wasAnyProjectFeatureModified = true;
      }
    }
    return [wasAnyProjectFeatureModified, shouldDisplayErrorMessage];
  }

  navigateToPrev() {
    this.router.navigate(['/post-project/overview'], { state: { projectId: this.projectId } });
  }

  async navigateToNext() {
    this.shouldDisplayErrorMessage = false;

    let projectFeatures: ProjectFeature[] = [];

    let hasSwitchedPackages = false;
    if (this.features?.hasPackages != this.hasPackages) {
      hasSwitchedPackages = true;
    }

    let hasModifiedAnyCheckboxFeature = false;
    let hasModifiedAnyDropdownFeature = false;
    let hasModifiedAnyTextAreaFeature = false;

    let shouldDisplayErrorMessageBecauseDropdown = false;
    let shouldDisplayErrorMessageBecauseTextArea = false;


    if (this.checkBoxOptions != undefined && this.dropdownOptions != undefined && this.textAreaOptions != undefined) {
      [hasModifiedAnyCheckboxFeature,] = this.addOptionsToProjectFeatures(this.checkBoxOptions, projectFeatures);
      [hasModifiedAnyDropdownFeature, shouldDisplayErrorMessageBecauseDropdown] = this.addOptionsToProjectFeatures(this.dropdownOptions, projectFeatures);
      [hasModifiedAnyTextAreaFeature, shouldDisplayErrorMessageBecauseTextArea] = this.addOptionsToProjectFeatures(this.textAreaOptions, projectFeatures);
    }

    if (shouldDisplayErrorMessageBecauseDropdown || shouldDisplayErrorMessageBecauseTextArea) {
      this.shouldDisplayErrorMessage = true;
      return;
    }

    if (hasSwitchedPackages || hasModifiedAnyCheckboxFeature || hasModifiedAnyDropdownFeature || hasModifiedAnyTextAreaFeature) {
      let request: AddOrUpdateProjectPricingDto = {
        features: projectFeatures,
        hasPackages: this.hasPackages ?? false
      }

      await this.projectService.putProjectPricing(request, this.projectId!);
    }

    this.router.navigate([`/post-project/description-faq/${this.skillSubcategoryId}`], { state: { projectId: this.projectId } });
  }

  isNotMandatoryFreeText(feature: DropdownOption){
    return feature.name !== "Package name" && feature.name !== "Package description" && feature.name !== "Price";
  }

  range = range;
}