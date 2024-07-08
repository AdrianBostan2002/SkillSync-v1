import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-editor-dialog',
  templateUrl: './editor-dialog.component.html',
  styleUrl: './editor-dialog.component.scss'
})
export class EditorDialogComponent {
  @Input() isDialogVisible: boolean = false;
  @Input() initialContent?: string;
  @Output() closeDialog: EventEmitter<void> = new EventEmitter<void>();
  @Output() contentChanged: EventEmitter<string> = new EventEmitter<string>();

  editorApiKey: string = environment.tinyMceApiKey;

  constructor(private formBuilder: FormBuilder) { }

  contentForm = this.formBuilder.group({
    content: ['', Validators.required]
  });

  ngOnChanges(changes: SimpleChanges) {
    if (changes['initialContent']) {
      this.contentForm.controls.content.setValue(this.initialContent ?? '');
    }
  }

  onCloseDialog() {
    this.closeDialog.emit();
  }

  onSave() {
    this.contentChanged.emit(this.contentForm.controls.content.value ?? '');
    this.onCloseDialog();
  }
}