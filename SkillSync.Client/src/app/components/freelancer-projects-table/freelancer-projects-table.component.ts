import { Component, Input } from '@angular/core';
import { FreelancerProjectDto } from '../../shared/entities/responses/freelancer-project-dto';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { ProjectService } from '../../services/project.service';
import { NotificationService } from '../../services/notification.service';
import { CurrencyConverterService } from '../../services/currency-converter.service';
import { CurrencyType } from '../../shared/enums/currency-type';

@Component({
  selector: 'app-freelancer-projects-table',
  templateUrl: './freelancer-projects-table.component.html',
  styleUrl: './freelancer-projects-table.component.css'
})
export class FreelancerProjectsTableComponent {
  @Input() projects?: FreelancerProjectDto[];
  logoPath: string = 'assets/resources/no-image-available.png';
  currencyType: { label: string, value: CurrencyType } = { label: 'USD', value: CurrencyType.USD };

  constructor(
    private router: Router,
    private tokenService: TokenService,
    private projectService: ProjectService,
    private currencyConverterService: CurrencyConverterService, 
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
    this.currencyConverterService.selectedCurrency$.subscribe(currency => {
      this.currencyType = currency;
    });
  }

  onSelectedProject(project: FreelancerProjectDto) {

    let freelancerName = removeWhiteSpaceAndCharactersForRoute(this.tokenService.getUsername() ?? '');
    let projectTitle = removeWhiteSpaceAndCharactersForRoute(project.title);

    this.router.navigate([`/project/${freelancerName}/${projectTitle}`], { state: { projectId: project.id } });
  }

  onEditProject(event: Event, project: FreelancerProjectDto) {
    event.stopPropagation();
    this.router.navigate(['/post-project/overview'], { state: { projectId: project.id } });
  }

  async onDeleteProject(event: Event, project: FreelancerProjectDto) {
    event.stopPropagation();
    await this.projectService.deleteProject(project.id);
    this.notificationService.displaySuccessMessage('Project deleted successfully');
    this.projects = this.projects?.filter(p => p.id !== project.id);
  }
}
