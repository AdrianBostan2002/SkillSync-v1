import { Component, Input, SimpleChanges } from '@angular/core';
import { SkillCategory } from '../../shared/entities/models/skill-category';
import { categoriesIcons, removeWhiteSpaceAndCharactersForRoute } from '../../shared/utils';
import { Router } from '@angular/router';

@Component({
  selector: 'app-services-list',
  templateUrl: './services-list.component.html',
  styleUrl: './services-list.component.css'
})
export class ServicesListComponent {
  @Input() categories: SkillCategory[] = [];
  categoriesWithIcons: { icon: string; category: SkillCategory }[] = [];
  constructor(private router: Router) { }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['categories']) {
      this.mapCategories();
    }
  }

  private mapCategories() {
    this.categories.forEach(category => {
      let icon = categoriesIcons(category.name);

      this.categoriesWithIcons.push({ icon: icon, category: category });
    });
  }

  onNavigateCategory(category: SkillCategory) {
    let newCategoryName = removeWhiteSpaceAndCharactersForRoute(category.name);

    this.router.navigate([`/categories/${newCategoryName}`], { state: { category: category } });
  }
}
