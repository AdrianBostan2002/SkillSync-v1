import { Component } from '@angular/core';
import { SelectItemGroup, TreeNode } from 'primeng/api';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { SkillCategoryService } from '../../services/skill-category.service';
import { Router } from '@angular/router';
import { TreeNodeSelectEvent, TreeNodeUnSelectEvent } from 'primeng/tree';
import { Skill } from '../../shared/entities/models/skill';
import { SkillSubcategory } from '../../shared/entities/models/skill-subcategory';
import { addRangeToArray } from '../../shared/utils';
import { FreelancerService } from '../../services/freelancer.service';
import { CompleteFreelancerExperienceRequest } from '../../shared/entities/requests/complete-freelancer-experience-request';
import { FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-freelancer-experience',
  templateUrl: './freelancer-experience.component.html',
  styleUrl: './freelancer-experience.component.css'
})
export class FreelancerExperienceComponent {
  groupedSkills: SelectItemGroup[] = [];

  mottoMessage: string = "Elevate Your Career: Join the World's Elite Talent Network!";
  completeProfileMessage: string = "Complete Your Profile: Unleash Your Potential";

  selectedItems: TreeNode[] = [];

  minDescriptionLength: number = 100;
  maxDescriptionLength: number = 1000;
  characterCounter: number = 0;

  characterCounterSubscription?: Subscription;

  private categories: SkillCategory[] = [];

  constructor
    (
      private skillCategoryService: SkillCategoryService,
      private freelancerService: FreelancerService,
      private router: Router,
      private formBuilder: FormBuilder
    ) { }

  async ngOnInit() {
    this.characterCounterSubscription = this.experienceInfoForm.controls.scopeDescription.valueChanges.subscribe(() => {
      this.onDescriptionChange();
    });

    this.categories = await this.skillCategoryService.getAllSkillCategories();

    this.groupedSkills = this.mapSkillsToSelectItemGroup(this.categories);
  }

  experienceInfoForm = this.formBuilder.group({
    scopeDescription: ['', [Validators.required, Validators.minLength(this.minDescriptionLength), Validators.maxLength(this.maxDescriptionLength)]],
  })

  onDescriptionChange() {
    const characters = this.experienceInfoForm.controls.scopeDescription.value;
    if (characters) {
      this.characterCounter = characters.length;
    } else {
      this.characterCounter = 0;
    }
  }

  private mapSkillsToSelectItemGroup(categories: SkillCategory[]): SelectItemGroup[] {
    return categories.map(category => ({
      label: category.name,
      value: category.name,
      items: [],
      parent: undefined,
      children: category.skillSubcategories.map(subcategory => ({
        label: subcategory.name,
        value: subcategory.name,
        parent: category,
        children: subcategory.skills.map(skill => ({
          label: skill.name,
          value: skill.name,
          parent: subcategory
        }))
      }))
    }));
  }

  onNodeSelect(event: TreeNodeSelectEvent): void {
    if (event.node.children && event.node.children.length > 0) {
      this.checkAndRemoveDescendants(event.node);
      this.selectedItems.push(event.node);
    } else {
      this.selectedItems.push(event.node);
    }
  }

  private checkAndRemoveDescendants(node: TreeNode): void {
    if (node.children) {
      for (const childNode of node.children) {
        const childIndex = this.selectedItems.findIndex(item => item.label === childNode.label);

        if (childIndex !== -1) {
          this.selectedItems.splice(childIndex, 1);
        }

        this.checkAndRemoveDescendants(childNode);
      }
    }
  }

  onNodeUnselect(event: TreeNodeUnSelectEvent): void {
    const unselectedNode = event.node;

    if (unselectedNode.parent) {
      const parentNode = unselectedNode.parent;

      const parentIndex = this.selectedItems.findIndex(item => item.label === parentNode.label);

      if (parentIndex !== -1) {
        this.addBrothersAndRemoveParent(parentNode, unselectedNode);
      } else {
        const unselectedIndex = this.selectedItems.findIndex(item => item.label === unselectedNode.label);
        if (unselectedIndex !== -1) {
          this.selectedItems.splice(unselectedIndex, 1);
        }
      }
    } else {
      const unselectedIndex = this.selectedItems.findIndex(item => item.label === unselectedNode.label);
      if (unselectedIndex !== -1) {
        this.selectedItems.splice(unselectedIndex, 1);
      }
    }
  }

  private addBrothersAndRemoveParent(parentNode: TreeNode, unselectedNode: TreeNode): void {
    const parentIndex = this.selectedItems.findIndex(item => item.label === parentNode.label);
    if (parentIndex !== -1) {
      this.selectedItems.splice(parentIndex, 1);
    }

    if (parentNode.children) {
      for (const brotherNode of parentNode.children) {
        if (brotherNode.label !== unselectedNode.label) {
          this.selectedItems.push(brotherNode);
        }
      }
    }
  }

  filterSelectedItems(): Skill[] {
    const filteredSkills: Skill[] = [];

    this.selectedItems.forEach(selectedItem => {
      const selectedCategory: SkillCategory | undefined = this.categories.find(
        category => category.name === selectedItem.label
      );

      if (selectedCategory) {
        selectedCategory.skillSubcategories.forEach(subcategory => {
          addRangeToArray(filteredSkills, subcategory.skills);
        });
      } else {
        this.categories.forEach(category => {
          const selectedSubcategory: SkillSubcategory | undefined = category.skillSubcategories.find(
            subcategory => subcategory.name === selectedItem.label
          );

          if (selectedSubcategory) {
            addRangeToArray(filteredSkills, selectedSubcategory.skills);
          } else {
            category.skillSubcategories.forEach(subcategory => {
              const selectedSkill: Skill | undefined = subcategory.skills.find(
                skill => skill.name === selectedItem.label
              );

              if (selectedSkill) {
                filteredSkills.push(selectedSkill);
              }
            });
          }
        });
      }
    });

    return filteredSkills;
  }

  async onContinue() {
    let selectedSkills: Skill[] = this.filterSelectedItems();

    let scopeDescriptionInput = this.experienceInfoForm.controls.scopeDescription.value;

    if (selectedSkills.length != 0 && scopeDescriptionInput != null && scopeDescriptionInput != '') {
      let newRequest: CompleteFreelancerExperienceRequest = {
        skills: selectedSkills,
        scopeDescription: scopeDescriptionInput
      }
      await this.freelancerService.completedFreelancerExperienceLevel(newRequest);
      this.router.navigate(["/orders"]);
    }
  }

  ngOnDestroy() {
    this.characterCounterSubscription?.unsubscribe();
  }
}