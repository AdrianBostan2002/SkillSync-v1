import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProjectService } from '../../services/project.service';
import { FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-review-dialog',
  templateUrl: './review-dialog.component.html',
  styleUrl: './review-dialog.component.scss'
})
export class ReviewDialogComponent {
  @Input() displayReviewDialog: boolean = false;
  @Input() projectId?: string;
  @Output() closeReviewDialog = new EventEmitter<void>();

  reviewForm = this.formBuilder.group({
    stars: [0, [Validators.required, Validators.min(1), Validators.max(5)]],
    content: ['', Validators.required]
  })

  constructor(private projectService: ProjectService, private notificationService: NotificationService, private formBuilder: FormBuilder) { }

  async onSubmit() {
    let stars = this.reviewForm.controls.stars.value;
    let content = this.reviewForm.controls.content.value;

    if (this.projectId && stars && content) {
      await this.projectService.postReview(this.projectId, content, stars);
      this.notificationService.displaySuccessMessage("Review submitted successfully!");
      this.closeDialog();
    }
  }

  closeDialog() {
    this.displayReviewDialog = false;
    this.closeReviewDialog.emit();
  }
}
