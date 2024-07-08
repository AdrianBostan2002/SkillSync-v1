import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment.development';
import { ConfirmationService } from 'primeng/api';
import { ProjectService } from '../../services/project.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FrequentlyAskedQuestion } from '../../shared/entities/models/frequently-asked-question';
import { ProjectDescriptionFaqDto } from '../../shared/entities/requests/add-project-steps/project-description-faq-dto';

@Component({
  selector: 'app-post-project-description-faq',
  templateUrl: './post-project-description-faq.component.html',
  styleUrl: './post-project-description-faq.component.scss',
  providers: [ConfirmationService]
})
export class PostProjectDescriptionFaqComponent {
  editorApiKey: string = environment.tinyMceApiKey;
  frequentlyAskedQuestions: FrequentlyAskedQuestion[] = [];

  isDialogVisible: boolean = false;
  projectId?: string;

  addOrUpdateQuestion!: FrequentlyAskedQuestion;
  isEditingQuestion: boolean = false;
  lastEditingQuestionIndex?: number;
  skillSubcategoryId: string = "";

  initialDescription?: string;
  initialQuestions?: FrequentlyAskedQuestion[];

  minDescriptionLenght: number = 100;
  maxDescriptionLenght: number = 5000;
  characterCounter: number = 0;

  descriptionForm = this.formBuilder.group({
    description: ['', [Validators.required, Validators.minLength(this.minDescriptionLenght), Validators.maxLength(this.maxDescriptionLenght)]]
  });

  constructor
    (
      private formBuilder: FormBuilder,
      private projectService: ProjectService,
      private router: Router,
      private route: ActivatedRoute
    ) { }

  async ngOnInit() {
    this.descriptionForm.controls.description.valueChanges.subscribe(() => {
      this.onDescriptionChange();
    });

    this.skillSubcategoryId = this.route.snapshot.params['id'];

    this.projectId = history.state.projectId;
    if (this.projectId) {
      let result = await this.projectService.getProjectDescriptionAndFaq(this.projectId);
      this.initialDescription = result.description;
      this.initialQuestions = result.frequentlyAskedQuestions;
      this.frequentlyAskedQuestions = this.initialQuestions.map(x => ({ ...x }));

      this.descriptionForm.patchValue({
        description: this.initialDescription
      });
    }
  }

  onDescriptionChange() {
    const projectDescription = this.descriptionForm.controls.description.value;
    if (projectDescription) {
      this.characterCounter = projectDescription.length;
    } else {
      this.characterCounter = 0;
    }
  }

  navigateToPrev() {
    this.router.navigate(
      [`/post-project/pricing/${this.skillSubcategoryId}`], { state: { projectId: this.projectId } }
    );
  }

  async navigateToNext() {
    let projectDescription = this.descriptionForm.controls.description.value;

    let wasAnyQuestionModified = this.checkIfAnyQuestionWasModified();

    if (!wasAnyQuestionModified) {
      this.frequentlyAskedQuestions = [];
    }

    if (projectDescription !== this.initialDescription || (wasAnyQuestionModified || (!wasAnyQuestionModified && this.frequentlyAskedQuestions.length == 0))) {
      let request: ProjectDescriptionFaqDto = {
        description: projectDescription ?? '',
        frequentlyAskedQuestions: this.frequentlyAskedQuestions,
        wasAnyQuestionModified: wasAnyQuestionModified
      }

      if (this.projectId) {
        await this.projectService.putProjectDescriptionFaq(request, this.projectId);
      }
    }

    this.router.navigate(
      [`/post-project/gallery/${this.skillSubcategoryId}`], { state: { projectId: this.projectId } }
    );
  }

  newQuestion() {
    this.addOrUpdateQuestion = {} as FrequentlyAskedQuestion;
    this.isDialogVisible = true;
    this.isEditingQuestion = false;
  }

  editQuestion(index: number) {
    this.addOrUpdateQuestion = this.frequentlyAskedQuestions[index];
    this.isDialogVisible = true;
    this.isEditingQuestion = true;
    this.lastEditingQuestionIndex = index;
  }

  removeQuestion(index: number) {
    this.frequentlyAskedQuestions.splice(index, 1);
  }

  onReceiveAddedOrUpdatedQuestion($event: FrequentlyAskedQuestion) {
    this.isDialogVisible = false;

    if (this.isEditingQuestion == true && this.lastEditingQuestionIndex != undefined) {
      this.frequentlyAskedQuestions[this.lastEditingQuestionIndex].question = $event.question;
      this.frequentlyAskedQuestions[this.lastEditingQuestionIndex].answer = $event.answer;
      this.isEditingQuestion = false;
      return;
    }

    if ($event != undefined) {
      this.frequentlyAskedQuestions.push($event);
    }
  }

  private checkIfAnyQuestionWasModified(): boolean {
    let initialQuestionLength = this.initialQuestions?.length ?? 0;

    if (initialQuestionLength != this.frequentlyAskedQuestions.length) {
      return true;
    }

    if (this.initialQuestions) {
      for (let i = 0; i < initialQuestionLength; i++) {
        if (this.initialQuestions[i]?.question != this.frequentlyAskedQuestions[i]?.question || this.initialQuestions[i]?.answer != this.frequentlyAskedQuestions[i]?.answer) {
          return true;
        }
      }
    }

    return false;
  }
}