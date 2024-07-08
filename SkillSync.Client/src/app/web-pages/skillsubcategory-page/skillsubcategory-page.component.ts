import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SkillSubcategory } from '../../shared/entities/models/skill-subcategory';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { GetProjectPreviewResponse } from '../../shared/entities/responses/get-projects-preview-response';
import { ProjectService } from '../../services/project.service';
import { PaginatorState } from 'primeng/paginator';
import { TokenService } from '../../services/token.service';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { ProjectQueryParams } from '../../shared/entities/requests/query-params/project-query-params';
import { ProjectPreviewResponse } from '../../shared/entities/responses/project-previews-response';

@Component({
  selector: 'app-skillsubcategory-page',
  templateUrl: './skillsubcategory-page.component.html',
  styleUrl: './skillsubcategory-page.component.css'
})
export class SkillsubcategoryPageComponent {
  subcategory?: SkillSubcategory;
  skill?: SkillCategory;
  allProjectsPreview?: ProjectPreviewResponse;
  projectsPreview?: GetProjectPreviewResponse[];

  subcategoryName: string | null = null;
  skillName: string | null = null;

  isSubCategoryPage: boolean = true;

  username?: string | null;

  projectQueryParams?: ProjectQueryParams;

  constructor
    (
      private route: ActivatedRoute,
      private projectService: ProjectService,
      private tokenService: TokenService,
      private router: Router
    ) { }

  async ngOnInit() {
    this.route.paramMap.subscribe(async (params) => {
      this.isSubCategoryPage = true;

      this.username = this.tokenService.getUsername();

      this.subcategory = history.state.subcategory;
      this.skill = history.state.skill;

      this.subcategoryName = params.get('subCategoryName');
      this.skillName = params.get('skillName');

      await this.getInitialProjects();
    });
  }

  private async getInitialProjects() {
    this.projectQueryParams = {
      pageNumber: this.firstPreviewIndex,
      pageSize: this.maxPreviewPerPageCount
    };

    if (this.skillName && this.skill) {
      this.allProjectsPreview = await this.projectService.getProjectsPreviewBySkillId(this.skill.id, this.projectQueryParams);

      this.sliceProjectsPreview(this.firstPreviewIndex, this.maxPreviewPerPageCount);
    }
    else if (this.subcategoryName && this.subcategory) {
      this.allProjectsPreview = await this.projectService.getProjectsPreviewBySubcategoryId(this.subcategory.id, this.projectQueryParams);

      this.sliceProjectsPreview(this.firstPreviewIndex, this.maxPreviewPerPageCount);
    }
  }

  private sliceProjectsPreview(start: number, end: number) {
    if (this.allProjectsPreview) {
      this.projectsPreview = this.allProjectsPreview.projects
        .slice(start, end)
        .map(project => JSON.parse(JSON.stringify(project)));
    }
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

  firstPreviewIndex: number = 0;

  maxPreviewPerPageCount: number = 8;

  async onPageChange(event: PaginatorState) {
    this.firstPreviewIndex = event.first ?? 0;
    if (this.allProjectsPreview && this.allProjectsPreview?.projects.length < this.allProjectsPreview?.totalProjectsCount) {
      if (this.projectQueryParams) {
        this.projectQueryParams.pageNumber = this.firstPreviewIndex / this.maxPreviewPerPageCount;
        this.projectQueryParams.pageSize = this.maxPreviewPerPageCount;
      } else {
        this.projectQueryParams = {
          pageNumber: this.firstPreviewIndex / this.maxPreviewPerPageCount,
          pageSize: this.maxPreviewPerPageCount
        }
      }

      if (this.skill) {
        let result = await this.projectService.getProjectsPreviewBySkillId(this.skill.id, this.projectQueryParams);

        this.concatReceivedNewProjectsPreview(result);
      }
      else if (this.subcategory) {
        let result = await this.projectService.getProjectsPreviewBySubcategoryId(this.subcategory.id, this.projectQueryParams);

        this.concatReceivedNewProjectsPreview(result);
      }
    }
    else {
      this.sliceProjectsPreview(this.firstPreviewIndex, this.firstPreviewIndex / this.maxPreviewPerPageCount * this.maxPreviewPerPageCount + this.maxPreviewPerPageCount);
    }
  }

  private concatReceivedNewProjectsPreview(result: ProjectPreviewResponse) {
    if (this.allProjectsPreview) {
      this.allProjectsPreview.totalProjectsCount = result.totalProjectsCount;
      this.allProjectsPreview.projects = this.allProjectsPreview.projects.concat(result.projects);

      this.sliceProjectsPreview(this.firstPreviewIndex, this.allProjectsPreview.projects.length);
    }
  }

  changeProjectFavoriteStatus(projectPreview: GetProjectPreviewResponse) {
    this.projectService.changeProjectFavoriteStatus(projectPreview.id, !projectPreview.isUserWhoMadeRequestFavorite);

    projectPreview.isUserWhoMadeRequestFavorite = !projectPreview.isUserWhoMadeRequestFavorite;
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

  async onFilterProjectsPreview(queryParams: ProjectQueryParams) {
    queryParams.pageNumber = this.firstPreviewIndex;
    queryParams.pageSize = this.maxPreviewPerPageCount;

    this.projectQueryParams = queryParams;

    if (this.skillName && this.skill) {
      this.allProjectsPreview = await this.projectService.getProjectsPreviewBySkillId(this.skill.id, queryParams);
    }
    else if (this.subcategory) {
      this.allProjectsPreview = await this.projectService.getProjectsPreviewBySubcategoryId(this.subcategory?.id, queryParams);
    }
    this.firstPreviewIndex = 0;

    this.sliceProjectsPreview(this.firstPreviewIndex, this.firstPreviewIndex / this.maxPreviewPerPageCount * this.maxPreviewPerPageCount + this.maxPreviewPerPageCount);
  }

  async onSearchProjects(searchText: string) {
    if (searchText.trim() === '') {
      this.getInitialProjects();
      return;
    }

    let projectPreviews: GetProjectPreviewResponse[] = [];
    if (this.skillName && this.skill) {
      projectPreviews = await this.projectService.searchProjects(searchText, false, false, this.skill.id);
    }
    else {
      projectPreviews = await this.projectService.searchProjects(searchText, false, true, this.subcategory?.id);
    }

    if (this.allProjectsPreview) {
      this.allProjectsPreview.projects = projectPreviews;
      this.allProjectsPreview.totalProjectsCount = projectPreviews.length;

      this.sliceProjectsPreview(this.firstPreviewIndex, this.firstPreviewIndex / this.maxPreviewPerPageCount * this.maxPreviewPerPageCount + this.maxPreviewPerPageCount);
    }
  }
}