import { Component } from '@angular/core';
import { FreelancerService } from '../../services/freelancer.service';
import { FreelancerProjectDto } from '../../shared/entities/responses/freelancer-project-dto';

@Component({
  selector: 'app-freelancer-projects-page',
  templateUrl: './freelancer-projects-page.component.html',
  styleUrl: './freelancer-projects-page.component.css'
})
export class FreelancerProjectsPageComponent {
  freelancerProjects: { isPublished: boolean, label: string, projects: FreelancerProjectDto[] }[] = [];

  async ngOnInit() {
    this.freelancerProjects = [
      { isPublished: true, label: 'Published', projects: [] },
      { isPublished: false, label: 'Not Published', projects: [] }
    ];

    this.freelancerProjects[0].projects = await this.freelancerService.getFreelancerProjectsByPublishStatus(this.freelancerProjects[0].isPublished);
  }

  constructor(private freelancerService: FreelancerService) { }

  async retrieveProjects(index: number) {
    if (this.freelancerProjects[index].projects.length == 0) {
      this.freelancerProjects[index].projects = await this.freelancerService.getFreelancerProjectsByPublishStatus(this.freelancerProjects[index].isPublished);
    }
  }
}