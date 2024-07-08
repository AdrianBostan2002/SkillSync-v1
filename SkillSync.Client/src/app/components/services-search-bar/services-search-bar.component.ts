import { Component, ViewChild } from '@angular/core';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { SkillSubcategory } from '../../shared/entities/models/skill-subcategory';
import { Skill } from '../../shared/entities/models/skill';
import { SkillCategoryService } from '../../services/skill-category.service';
import { SkillBase } from '../../shared/entities/models/skillbase';
import { OverlayPanel } from 'primeng/overlaypanel';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './services-search-bar.component.html',
  styleUrl: './services-search-bar.component.css'
})
export class ServicesSearchBarComponent {
  @ViewChild('overlayPanel') overlayPanel?: OverlayPanel;
  searchText: string = '';
  skillCategories: SkillCategory[] = [];
  allItems: SkillBase[] = [];
  filteredResults: (SkillBase | any)[] = [];

  constructor(private skillCategoryService: SkillCategoryService, private router: Router) { }

  private async getSkillCategories() {
    this.skillCategories = await this.skillCategoryService.getAllSkillCategories();
  }

  async search(event: any): Promise<void> {
    if (this.skillCategories.length === 0) {
      await this.getSkillCategories();
      this.allItems = [];
      this.skillCategories.forEach(category => {
        this.allItems.push({
          id: category.id,
          name: category.name,
          description: category.description,
        });

        category.skillSubcategories.forEach(subcategory => {
          this.allItems.push({
            id: subcategory.id,
            name: subcategory.name,
            description: subcategory.description,
          });

          subcategory.skills.forEach(skill => {
            this.allItems.push({
              id: skill.id,
              name: skill.name,
              description: skill.description,
            });
          });
        });
      });
    }

    if (this.searchText.trim() !== '') {
      this.filteredResults = this.allItems.filter(item => {
        return (
          item.name.toLowerCase().includes(this.searchText.toLowerCase()) ||
          item.description.toLowerCase().includes(this.searchText.toLowerCase())
        );
      });

      if (this.filteredResults.length > 0) {
        if (!this.overlayPanel?.overlayVisible) {
          this.overlayPanel?.toggle(event);
        }
      }
      else {
        this.overlayPanel?.hide();
      }

    } else {
      this.overlayPanel?.hide();
    }
  }

  selectSkill(skill: SkillBase): void {
    for (const category of this.skillCategories) {
      if (category.id === skill.id || category.name === skill.name) {
        this.onNavigateCategory(category);
        return;
      }
      for (const subcategory of category.skillSubcategories) {
        if (subcategory.id === skill.id || subcategory.name === skill.name) {
          this.onNavigateSubcategory(subcategory);
          return;
        }
        for (const subSkill of subcategory.skills) {
          if (subSkill.id === skill.id || subSkill.name === skill.name) {
            this.onNavigateSkill(subcategory, subSkill);
            return;
          }
        }
      }
    }
  }

  onNavigateCategory(category: SkillCategory) {
    let newCategoryName = removeWhiteSpaceAndCharactersForRoute(category.name);

    this.router.navigate([`/categories/${newCategoryName}`], { state: { category: category } });
  }

  onNavigateSubcategory(subcategory: SkillSubcategory) {
    let newSubcategoryName = removeWhiteSpaceAndCharactersForRoute(subcategory.name);

    this.router.navigate([`/subcategories/${newSubcategoryName}`], { state: { subcategory: subcategory } });
  }

  onNavigateSkill(subcategory: SkillSubcategory, skill: Skill) {
    let newSubcategoryName = removeWhiteSpaceAndCharactersForRoute(subcategory.name);
    let newSkillName = removeWhiteSpaceAndCharactersForRoute(skill.name);

    this.router.navigate([`/subcategories/${newSubcategoryName}/skills/${newSkillName}`], { state: { skill: skill } });
  }
}