import { Component, ChangeDetectorRef } from '@angular/core';
import { ProjectService } from '../../services/project.service';
import { ActivatedRoute, Router } from '@angular/router';
import { GetProjectResponse } from '../../shared/entities/responses/get-project-response';
import { FileType } from '../../shared/enums/file-type';
import { countriesAndCode, removeWhiteSpaceAndCharactersForRoute, setReviewStatistics, toRoleType } from '../../shared/utils';
import { GetProjectFeatureResponse } from '../../shared/entities/responses/get-project-feature-response';
import { Media } from '../../shared/entities/models/media';
import { TokenService } from '../../services/token.service';
import { PackageType } from '../../shared/enums/packages';
import { ReviewStatistic } from '../../shared/entities/models/reviews-statistic';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../../shared/enums/currency-type';
import { NotificationService } from '../../services/notification.service';
import { RoleType } from '../../shared/enums/role-type';

@Component({
  selector: 'app-project-page',
  templateUrl: './project-page.component.html',
  styleUrl: './project-page.component.css'
})
export class ProjectPageComponent {
  project?: GetProjectResponse;
  pictureIndex: number = 0;

  allMedia?: Media[];

  imageFileType = FileType.Image;
  videoFileType = FileType.Video;

  basicPackageType: PackageType = PackageType.Basic;
  standardPackageType: PackageType = PackageType.Standard;
  premiumPackageType: PackageType = PackageType.Premium;

  currentSelectedPackageType: PackageType = PackageType.Basic;

  freelancerCountryName?: string;
  currentUserEmail?: string;
  currentUserRole?: RoleType | null;

  basicPackageFeatureDescription?: string[];
  standardPackageFeatureDescription?: string[];
  premiumPackageFeatureDescription?: string[];
  price: number[] = [0, 0, 0];
  packageName: string[] = ["", "", ""];
  packageDescription: string[] = ["", "", ""];

  displayContinueButton?: boolean;
  displayCustomerObligations: boolean = false;

  currencyType: { label: string, value: CurrencyType } = { label: 'USD', value: CurrencyType.USD };

  reviewStatistics?: ReviewStatistic[];

  constructor
    (
      private projectService: ProjectService,
      private route: ActivatedRoute,
      private tokenService: TokenService,
      private currencyConverterService: CurrencyConverterService,
      private notificationService: NotificationService,
      private router: Router
    ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(async params => {
      let projectId = history.state.projectId;

      this.currentUserEmail = this.tokenService.getEmail() ?? '';
      this.currentUserRole = toRoleType(this.tokenService.getRole());

      this.setDisplayContinueButton();

      this.project = await this.projectService.getProjectById(projectId);

      this.sortFeaturesByCheckBoxOption();
      this.mapAllMedia(this.project);
      this.mapPackageFeatureDescriptions();

      this.mapReviewStatistics();

      let country = countriesAndCode.filter(countryAndCode => countryAndCode.code == this.project?.freelancer.countryCode)[0];
      this.freelancerCountryName = country.name;

      const tempDiv = document.createElement('description');

      tempDiv.innerHTML = this.project.description;

      const container = document.getElementById('descriptionContainer');
      if (container) {
        container.appendChild(tempDiv);
      }

      this.currencyConverterService.selectedCurrency$.subscribe(currency => {
        this.currencyType = currency;
      });
    });
  }

  private mapReviewStatistics() {
    this.reviewStatistics = this.setReviewStatistics(this.project?.reviews ?? []);
  }

  setReviewStatistics = setReviewStatistics;

  sortFeaturesByCheckBoxOption() {
    if (this.project?.features) {
      this.project.features = this.project.features.sort((a, b) => {
        if (a.basicSelectedValue === b.basicSelectedValue) {
          return 0;
        }

        if (a.basicSelectedValue === 'true' || a.basicSelectedValue === 'false') {
          return -1;
        } else {
          return 1;
        }
      });
    }
  }

  mapAllMedia(project: GetProjectResponse) {
    this.allMedia = [];
    project.pictures.forEach(picture => {
      this.allMedia?.push({ url: picture, fileType: FileType.Image });
    });

    if (project.video != null) {
      this.allMedia?.push({ url: project.video, fileType: FileType.Video });
    }
  }

  mapPackageFeatureDescriptions() {
    let maxCheckBoxOptions = 4;
    let basicCheckBoxOptionsCounter = 0;
    let standardCheckBoxOptionsCounter = 0;
    let premiumCheckBoxOptionsCounter = 0;

    this.basicPackageFeatureDescription = [];
    this.standardPackageFeatureDescription = [];
    this.premiumPackageFeatureDescription = [];

    if (this.project?.features) {
      this.project.features = this.project.features.filter(feature => {
        if (basicCheckBoxOptionsCounter <= maxCheckBoxOptions) {
          if (this.isSpecialOption(feature)) {
            return false;
          }
        }
        return true;
      });
    }

    this.project?.features.forEach(feature => {
      if (feature.basicSelectedValue === 'true') {
        if (basicCheckBoxOptionsCounter <= maxCheckBoxOptions) {
          this.basicPackageFeatureDescription?.push((feature.name ?? '').toLowerCase());
          basicCheckBoxOptionsCounter++;
          if (this.project?.hasPackages) {
            if (feature.standardSelectedValue === 'true' && standardCheckBoxOptionsCounter <= maxCheckBoxOptions) {
              this.standardPackageFeatureDescription?.push((feature.name ?? '').toLowerCase());
              standardCheckBoxOptionsCounter++;
            }
            if (feature.premiumSelectedValue === 'true' && premiumCheckBoxOptionsCounter <= maxCheckBoxOptions) {
              this.premiumPackageFeatureDescription?.push((feature.name ?? '').toLowerCase());
              premiumCheckBoxOptionsCounter++;
            }
          }
        }
      }
      else if (feature.basicSelectedValue != null && feature.basicSelectedValue != 'false' && feature.name != 'Price') {
        this.basicPackageFeatureDescription?.push((`${feature.basicSelectedValue} ${feature.name}`).toLowerCase())
      }
    });
  }

  isSpecialOption(feature: GetProjectFeatureResponse) {
    if (feature.name == "Price") {
      this.price[0] = Number(feature.basicSelectedValue);
      this.price[1] = Number(feature.standardSelectedValue);
      this.price[2] = Number(feature.premiumSelectedValue);
      return true;
    }
    else if (feature.name === "Package name") {
      this.packageName[0] = feature.basicSelectedValue;
      this.packageName[1] = feature.standardSelectedValue;
      this.packageName[2] = feature.premiumSelectedValue;
      return true;
    }
    else if (feature.name === "Package description") {
      this.packageDescription[0] = feature.basicSelectedValue;
      this.packageDescription[1] = feature.standardSelectedValue;
      this.packageDescription[2] = feature.premiumSelectedValue;
      return true;
    }

    return false;
  }

  isPackageComparisonSpecialOption(feature: GetProjectFeatureResponse) {
    return feature.name === "Package name" || feature.name === "Package description" || feature.name === "Price";
  }

  onPreviousProjectPreviewImage() {
    let lenght = this.allMedia?.length;
    if (!this.pictureIndex && lenght) {
      this.pictureIndex = (lenght - 1);
      return;
    }

    this.pictureIndex = (this.pictureIndex - 1) % (lenght ?? 0);
  }

  onNextProjectPreviewImage() {
    let lenght = this.allMedia?.length;
    if (!this.pictureIndex) {
      this.pictureIndex = 0;
    }

    this.pictureIndex = (this.pictureIndex + 1) % (lenght ?? 0);
  }

  onContinueButton() {
    if (!this.currentUserEmail) {
      this.notificationService.displayInfoMessage("You need to be logged in to continue");
      return;
    }

    this.displayCustomerObligations = true;
  }

  setDisplayContinueButton() {
    if (this.currentUserEmail === this.project?.freelancer.email) {
      this.displayContinueButton = false;
      return;
    }

    if (this.currentUserRole === RoleType.Freelancer) {
      this.displayContinueButton = false;
      return;
    }

    this.displayContinueButton = true;
  }

  onFreelancerProfileSelected() {
    let freelancerName = removeWhiteSpaceAndCharactersForRoute(this.project?.freelancer.name ?? '');

    this.router.navigate([`/freelancer/${freelancerName}`], { state: { freelancerId: this.project?.freelancer.id } });
  }

  tabpanelChanged(index: number){
    this.currentSelectedPackageType = index as PackageType;
  }
}