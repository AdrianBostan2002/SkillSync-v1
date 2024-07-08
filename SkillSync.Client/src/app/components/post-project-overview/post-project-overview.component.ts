import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { SkillCategoryService } from '../../services/skill-category.service';
import { Skill } from '../../shared/entities/models/skill';
import { DropdownChangeEvent } from 'primeng/dropdown';
import { SkillSubcategory } from '../../shared/entities/models/skill-subcategory';
import { ProjectService } from '../../services/project.service';
import { ProjectOverviewDto } from '../../shared/entities/requests/add-project-steps/project-overview-dto';

@Component({
  selector: 'app-post-project-overview',
  templateUrl: './post-project-overview.component.html',
  styleUrl: './post-project-overview.component.scss'
})
export class PostProjectOverviewComponent {
  skillCategories: SkillCategory[] = [];

  skillSubcategories?: SkillSubcategory[];
  skills?: Skill[];

  projectId?: string;
  receivedProjectOverview?: ProjectOverviewDto;

  selectedSkillCategory?: SkillCategory;
  selectedSkillSubcategory?: SkillSubcategory;
  selectedSkill?: Skill;

  titleDescription: string = "Your title is the most important place to include keywords that buyers would likely use to search for a service like yours.";
  characterCounter: number = 0;

  minTitleLenght: number = 25;
  maxTitleLenght: number = 100;

  overviewForm = this.formBuilder.group({
    projectTitle: ['', Validators.required],
    skill: [undefined as unknown as Skill, [Validators.required, Validators.minLength(this.minTitleLenght), Validators.maxLength(this.maxTitleLenght)]]
  });

  constructor
    (
      private router: Router,
      private formBuilder: FormBuilder,
      private skillCategoryService: SkillCategoryService,
      private projectService: ProjectService
    ) { }

  async ngOnInit() {
    this.skillCategories = await this.skillCategoryService.getAllSkillCategories();

    this.projectId = history.state.projectId;

    this.overviewForm.controls.projectTitle.valueChanges.subscribe(() => {
      this.onTitleChange();
    });

    if (this.projectId) {
      this.receivedProjectOverview = await this.projectService.getProjectOverview(this.projectId);

      if (this.receivedProjectOverview) {
        this.overviewForm.patchValue({
          projectTitle: this.receivedProjectOverview.title
        });

        this.setSkillCategorySubcategoryAndSkill(this.receivedProjectOverview.skillId);
      }
    }
  }

  onTitleChange() {
    const projectTitle = this.overviewForm.controls.projectTitle.value;
    if (projectTitle) {
      this.characterCounter = projectTitle.length;
    } else {
      this.characterCounter = 0;
    }
  }

  async navigateToNext() {
    let projecTitle = this.overviewForm.controls.projectTitle.value;
    let skill = this.overviewForm.controls.skill.value;
    if (projecTitle != null && skill != null) {
      let projectId: string | undefined = this.projectId;

      let request: ProjectOverviewDto = {
        title: projecTitle,
        skillId: skill.id
      }
      if (this.receivedProjectOverview == undefined) {
        let response: any = await this.projectService.postProjectOverview(request);
        projectId = response.projectId;
      }
      else if (this.receivedProjectOverview != undefined && this.receivedProjectOverview.title != projecTitle || this.receivedProjectOverview.skillId != skill.id) {
        await this.projectService.putProjectOverview(request, this.projectId!);
      }

      if (projectId) {
        this.router.navigate(
          [`/post-project/pricing/${this.selectedSkillSubcategory?.id}`], { state: { projectId: projectId } }
        );
      }
    }
  }

  onSkillCategoryChange() {
    if (this.selectedSkillCategory == undefined) {
      this.setFormSkillValue(undefined);
    }
  }

  onSkillSubcategoryChange() {
    if (this.selectedSkillCategory == undefined) {
      this.setFormSkillValue(undefined);
    }
  }

  onSkillChange(event: DropdownChangeEvent) {
    this.setFormSkillValue(event.value);
  }

  setFormSkillValue(skill: Skill | undefined) {
    this.overviewForm.patchValue({
      skill: skill
    })
  }

  private setSkillCategorySubcategoryAndSkill(skillId: string) {
    this.skillCategories.forEach(skillCategory => {
      skillCategory.skillSubcategories.forEach(skillSubcategory => {
        skillSubcategory.skills.forEach(skill => {
          if (skill.id == skillId) {
            this.selectedSkillCategory = skillCategory;
            this.selectedSkillSubcategory = skillSubcategory;
            this.selectedSkill = skill;
            this.overviewForm.patchValue({
              skill: skill
            });
          }
        });
      });
    });
  }
}
