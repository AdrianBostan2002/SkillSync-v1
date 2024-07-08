import { Component, Input, SimpleChanges } from '@angular/core';
import { GetProjectReviewDto } from '../../shared/entities/responses/get-project-review-dto';

@Component({
  selector: 'app-review-section',
  templateUrl: './review-section.component.html',
  styleUrl: './review-section.component.css'
})
export class ReviewSectionComponent {
  @Input() review?: GetProjectReviewDto;
  stars: number = 0;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['review']) {
      this.stars = this.review?.stars ?? 0;
    }
  }
}
