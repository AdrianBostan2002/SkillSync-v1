import { Component, Input } from '@angular/core';
import { GetProjectPreviewResponse } from '../../shared/entities/responses/get-projects-preview-response';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { ProjectService } from '../../services/project.service';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../../shared/enums/currency-type';

@Component({
  selector: 'app-project-preview-card',
  templateUrl: './project-preview-card.component.html',
  styleUrl: './project-preview-card.component.css'
})
export class ProjectPreviewCardComponent {
  @Input() preview: GetProjectPreviewResponse;
  @Input() isFreelancerPage: boolean = false;

  currencyType: { label: string, value: CurrencyType } = { label: 'USD', value: CurrencyType.USD };
  username?: string | null;

  constructor(
    private router: Router, 
    private projectService: ProjectService, 
    private tokenService: TokenService,
    private currencyConverterService: CurrencyConverterService
  ) {
    this.preview = {} as GetProjectPreviewResponse;
  }

  ngOnInit() {
    this.currencyConverterService.selectedCurrency$.subscribe(currency => {
      this.currencyType = currency;
    });
    
    this.username = this.tokenService.getUsername();
  }

  onSelectedProjectPreview(projectPreview: GetProjectPreviewResponse) {
    let freelancerName = removeWhiteSpaceAndCharactersForRoute(projectPreview.freelancerName);
    let projectTitle = removeWhiteSpaceAndCharactersForRoute(projectPreview.title);

    this.router.navigate([`/project/${freelancerName}/${projectTitle}`], { state: { projectId: projectPreview.id } });
  }

  onFreelancerProfileSelected(projectPreview: GetProjectPreviewResponse) {
    let freelancerName = removeWhiteSpaceAndCharactersForRoute(projectPreview.freelancerName);

    this.router.navigate([`/freelancer/${freelancerName}`], { state: { freelancerId: projectPreview.freelancerId } });
  }

  onNextProjectPreviewImage(preview: GetProjectPreviewResponse) {
    let lenght = preview.pictures.length;
    if (!preview.pictureIndex) {
      preview.pictureIndex = 0;
    }

    preview.pictureIndex = (preview.pictureIndex + 1) % lenght;
  }

  onPreviousProjectPreviewImage(preview: GetProjectPreviewResponse) {
    let lenght = preview.pictures.length;
    if (!preview.pictureIndex) {
      preview.pictureIndex = (lenght - 1);
      return;
    }

    preview.pictureIndex = (preview.pictureIndex - 1) % lenght;
  }

  changeProjectFavoriteStatus(projectPreview: GetProjectPreviewResponse) {
    this.projectService.changeProjectFavoriteStatus(projectPreview.id, !projectPreview.isUserWhoMadeRequestFavorite);

    projectPreview.isUserWhoMadeRequestFavorite = !projectPreview.isUserWhoMadeRequestFavorite;
  }
}