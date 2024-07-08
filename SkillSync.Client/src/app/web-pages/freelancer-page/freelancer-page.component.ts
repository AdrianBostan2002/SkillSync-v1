import { Component } from '@angular/core';
import { FreelancerService } from '../../services/freelancer.service';
import { FreelancerDto } from '../../shared/entities/responses/freelancer-dto';
import { countriesAndCode, removeWhiteSpaceAndCharactersForRoute, setReviewStatistics } from '../../shared/utils';
import { FreelancerSkillsDto } from '../../shared/entities/responses/freelancer-skills-dto';
import { Router } from '@angular/router';
import { SkillService } from '../../services/skill.service';
import { PaginatorState } from 'primeng/paginator';
import { GetProjectPreviewResponse } from '../../shared/entities/responses/get-projects-preview-response';
import { User } from '../../shared/entities/models/user';
import { TokenService } from '../../services/token.service';
import { ReviewStatistic } from '../../shared/entities/models/reviews-statistic';
import { GetFreelancerReviewDto } from '../../shared/entities/responses/get-freelancer-review-dto';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-freelancer-page',
  templateUrl: './freelancer-page.component.html',
  styleUrl: './freelancer-page.component.css'
})
export class FreelancerPageComponent {
  freelancerId?: string;

  freelancer?: FreelancerDto;
  freelancerCountryName?: string;

  projectsPreview?: GetProjectPreviewResponse[];
  reviewStatistics?: ReviewStatistic[];

  currentUserEmail?: string;
  constructor
    (
      private router: Router,
      private freelancerService: FreelancerService,
      private skillService: SkillService,
      private tokenService: TokenService,
      private notificationService: NotificationService
    ) { }

  async ngOnInit() {
    this.freelancerId = history.state.freelancerId;
    let historyFreelancer = history.state.freelancerDto;

    const username = this.tokenService.getEmail();
    this.currentUserEmail = username !== null ? username : undefined;

    if (this.freelancerId) {
      this.freelancer = await this.freelancerService.getFreelancerById(this.freelancerId);
    }
    else if (historyFreelancer) {
      this.freelancer = historyFreelancer;
    }

    let country = countriesAndCode.filter(countryAndCode => countryAndCode.code == this.freelancer?.countryCode)[0];
    this.freelancerCountryName = country.name;
    this.projectsPreview = this.freelancer?.projects.slice(this.firstPreviewIndex, this.maxPreviewPerPageCount);
    this.reviewStatistics = this.setReviewStatistics(this.freelancer?.reviews.reviews ?? []);
  }

  setReviewStatistics = setReviewStatistics;

  async onSelectedSkill(selectedSkill: FreelancerSkillsDto) {
    let newSkillName = removeWhiteSpaceAndCharactersForRoute(selectedSkill.skillName);

    let skill = await this.skillService.getSkillById(selectedSkill.skillId);

    this.router.navigate([`/services/${newSkillName}`], { state: { skill: skill } });
  }

  firstPreviewIndex: number = 0;

  maxPreviewPerPageCount: number = 2;

  onPageChange(event: PaginatorState) {
    this.firstPreviewIndex = event.first ?? 0;

    let lastPreviewIndex = this.firstPreviewIndex + this.maxPreviewPerPageCount;

    let allProjectsPreviewCount = this.freelancer?.projects?.length ?? 0;

    lastPreviewIndex = Math.min(lastPreviewIndex, allProjectsPreviewCount);

    this.projectsPreview = this.freelancer?.projects?.slice(this.firstPreviewIndex, lastPreviewIndex);
  }

  contactFreelancer() {
    if (!this.currentUserEmail) {
      this.notificationService.displayInfoMessage('You need to be logged in to contact the freelancer');
      return;
    }

    if (this.freelancer) {
      this.router.navigate(['/chat'], { state: { toUser: this.freelancer as User } });
    }
  }

  onSelectedProjectReview(review: GetFreelancerReviewDto) {
    let title = this.freelancer?.reviews?.projects?.[review.projectId]?.name;
    let projectTitle = removeWhiteSpaceAndCharactersForRoute(title ?? '');

    this.router.navigate([`/project/${projectTitle}`], { state: { projectId: review.projectId } });
  }
}