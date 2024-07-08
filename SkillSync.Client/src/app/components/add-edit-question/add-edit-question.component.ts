import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FrequentlyAskedQuestion } from '../../shared/entities/models/frequently-asked-question';

@Component({
  selector: 'app-add-edit-question',
  templateUrl: './add-edit-question.component.html',
  styleUrl: './add-edit-question.component.css'
})
export class AddEditQuestionComponent {
  @Input() isDialogVisible!: boolean;
  @Input() question!: FrequentlyAskedQuestion;
  @Output() questionModified = new EventEmitter<FrequentlyAskedQuestion>();

  currentQuestion!: FrequentlyAskedQuestion;

  qAndAForm = this.formBuilder.group({
    question: ['', Validators.required],
    answer: ['', Validators.required]
  })

  constructor(private formBuilder: FormBuilder){}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['question'] && !changes['question'].firstChange) {
      this.onQuestionChanged();
    }
  }

  onQuestionChanged() {
    this.currentQuestion = { question: this.question.question, answer: this.question.answer };
    this.qAndAForm.patchValue({
      question : this.currentQuestion.question,
      answer : this.currentQuestion.answer
    })
  }

  onSave() {
    let question = this.qAndAForm.controls.question.value;
    let answer = this.qAndAForm.controls.answer.value;
    if(question!=undefined && answer!=undefined){
      this.currentQuestion.question = question;
      this.currentQuestion.answer = answer;
      this.questionModified.emit(this.currentQuestion);
      this.qAndAForm.reset();
    }
  }

  onCancel() {
    this.questionModified.emit(undefined);
    this.qAndAForm.reset();
  }
}
