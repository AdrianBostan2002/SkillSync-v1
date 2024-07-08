import { Component, Input } from '@angular/core';
import { ReviewStatistic } from '../../shared/entities/models/reviews-statistic';

@Component({
  selector: 'app-reviews-statistic',
  templateUrl: './reviews-statistic.component.html',
  styleUrl: './reviews-statistic.component.css'
})
export class ReviewsStatisticComponent {
  @Input() reviewStatistics: ReviewStatistic[] = [];
  @Input() totalReviews: number = 1;
}