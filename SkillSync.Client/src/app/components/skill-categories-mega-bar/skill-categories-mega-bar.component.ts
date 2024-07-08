import { Component } from '@angular/core';
import { SkillCategoryService } from '../../services/skill-category.service';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { Router } from '@angular/router';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { Skill } from '../../shared/entities/models/skill';
import { SkillSubcategory } from '../../shared/entities/models/skill-subcategory';

@Component({
  selector: 'app-skill-categories-mega-bar',
  templateUrl: './skill-categories-mega-bar.component.html',
  styleUrl: './skill-categories-mega-bar.component.css'
})
export class SkillCategoriesMegaBarComponent {
  skillCategories: SkillCategory[] = [];

  constructor(private skillCategoryService: SkillCategoryService, private router: Router) { }

  async ngOnInit() {
    this.skillCategories = await this.skillCategoryService.getAllSkillCategories();
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

    this.router.navigate([`/subcategories/${newSubcategoryName}/skills/${newSkillName}`], { state: { subcategory: subcategory, skill: skill } });
  }
}
