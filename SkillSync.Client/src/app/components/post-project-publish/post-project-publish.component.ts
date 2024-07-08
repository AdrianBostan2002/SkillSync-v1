import { Component } from '@angular/core';
import { ProjectService } from '../../services/project.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';

@Component({
  selector: 'app-post-project-publish',
  templateUrl: './post-project-publish.component.html',
  styleUrl: './post-project-publish.component.css'
})
export class PostProjectPublishComponent {
  acceptTermsConditionsMessage: string = "By checking this box, I confirm that I have read the document and agree to abide by its terms and conditions.";
  publishMessage: string = "If terms and conditions are not accepted, the project will not be published. It will be saved as a draft. You can publish it later."
  initialProjectPublishStatus?: boolean;
  hasAcceptedTermsConditions: boolean = false;

  skillSubcategoryId: string = "";
  projectId?: string;

  constructor
    (
      private route: ActivatedRoute,
      private router: Router,
      private projectService: ProjectService,
      private tokenService: TokenService
    ) { }

  async ngOnInit() {
    this.skillSubcategoryId = this.route.snapshot.params['id'];
    this.projectId = history.state.projectId;

    if (this.projectId) {
      this.hasAcceptedTermsConditions = await this.projectService.getPublishStatus(this.projectId);
      this.initialProjectPublishStatus = this.hasAcceptedTermsConditions;
    }
  }

  navigateToPrev() {
    this.router.navigate(
      [`/post-project/gallery/${this.skillSubcategoryId}`], { state: { projectId: this.projectId } }
    );
  }

  async navigateToNext() {
    if (this.initialProjectPublishStatus !== this.hasAcceptedTermsConditions && this.projectId) {
      await this.projectService.modifyPublishStatus(this.projectId, this.hasAcceptedTermsConditions);
    }

    if (this.projectId) {
      let freelancerName = "user";
      let username = this.tokenService.getUsername();
      if (username != null) {
        freelancerName = removeWhiteSpaceAndCharactersForRoute(username);
      }

      let request = await this.projectService.getProjectOverview(this.projectId);
      let projectTitle = request.title;
      projectTitle = removeWhiteSpaceAndCharactersForRoute(projectTitle);

      this.router.navigate([`/project/${freelancerName}/${projectTitle}`], { state: { projectId: this.projectId } });
    }
    else {
      this.router.navigate(['/landing-page']);
    }
  }
}