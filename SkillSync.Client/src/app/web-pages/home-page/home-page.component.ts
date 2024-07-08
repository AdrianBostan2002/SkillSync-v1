import { Component, HostListener, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SkillCategoryService } from '../../services/skill-category.service';
import { SkillCategory } from '../../shared/entities/models/skill-category';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
})
export class HomePageComponent implements OnInit {
  private destroy$ = new Subject<void>();
  loading = false;
  categories: SkillCategory[] = [];

  constructor(private categoryService: SkillCategoryService) { }

  async ngOnInit() { }

  private async loadCategories() {
    this.loading = true;
    this.categories = await this.categoryService.getAllSkillCategories();
  }

  @HostListener('window:scroll', ['$event'])
  onScroll(): void {
    if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight && !this.loading) {
      if (this.categories.length == 0) {
        this.loadCategories();
      }
    }
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}