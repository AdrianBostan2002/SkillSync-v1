import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { FrequentlyAskedQuestion } from '../../shared/entities/models/frequently-asked-question';
import { SkillSubcategory } from '../../shared/entities/models/skill-subcategory';
import { removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { SkillCategoryService } from '../../services/skill-category.service';

@Component({
  selector: 'app-skillcategory-page',
  templateUrl: './skillcategory-page.component.html',
  styleUrl: './skillcategory-page.component.css'
})
export class SkillcategoryPageComponent {
  category?: SkillCategory;

  subcategoryWithPictures: { pictureUrl: string; subcategory: SkillSubcategory }[] = [];

  frequentlyAskedQuestions: FrequentlyAskedQuestion[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private skillCategoryService: SkillCategoryService) { }

  async ngOnInit() {
    this.route.paramMap.subscribe(async params => {
      const categoryName = params.get('categoryName');
      this.category = history.state.category;

      this.category?.skillSubcategories.forEach(subcategory => {
        this.subcategoryWithPictures.push({ pictureUrl: `assets/resources/categories/${removeWhiteSpaceAndCharactersForRoute(subcategory.name)}.jpg`, subcategory: subcategory });
      });

      if (this.category) {
        this.frequentlyAskedQuestions = await this.skillCategoryService.getFrequentlyAskedQuestions(this.category.id);
      }
    });
  }

  onSelectedSubcategory(subcategory: SkillSubcategory) {
    let newSubcategoryName = removeWhiteSpaceAndCharactersForRoute(subcategory.name);

    this.router.navigate([`/subcategories/${newSubcategoryName}`], { state: { subcategory: subcategory } });
  }

  getEncodedUrl(pictureUrl: string): string {
    return encodeURI(pictureUrl);
  }
}