import { Component } from '@angular/core';
import { RoleType } from '../../shared/enums/role-type';
import { FreelancerService } from '../../services/freelancer.service';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { toRoleType } from '../../shared/utils';
import { SkillCategoryService } from '../../services/skill-category.service';
import { SkillCategory } from '../../shared/entities/models/skill-category';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  categories: SkillCategory[] = [];

  constructor
    (
      private freelancerService: FreelancerService, private router: Router,
      private tokenService: TokenService,
      private categoryService: SkillCategoryService
    ) { }

  async ngOnInit() {
    let tokenRole = await this.tokenService.getRole();

    let role = toRoleType(tokenRole);

    if (role == RoleType.Freelancer) {
      let hasCompletedFreelancerExperienceInfos = await this.freelancerService.getFreelancerHasCompletedExperienceLevel();

      if (!hasCompletedFreelancerExperienceInfos) {
        this.router.navigate(["freelancer-experience"]);
      }
      else {
        this.router.navigate(["freelancer-projects"]);
      }
    }

    this.categories = await this.categoryService.getAllSkillCategories();
  }
}