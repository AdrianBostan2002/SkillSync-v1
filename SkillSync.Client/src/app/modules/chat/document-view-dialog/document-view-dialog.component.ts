import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { ChatMessage } from '../../../shared/entities/models/chat-message';
import { ChatMessageType } from '../../../shared/enums/chat-message-type';
import { checkIfDocumentIsWord } from '../../../shared/utils';

@Component({
  selector: 'app-document-view-dialog',
  templateUrl: './document-view-dialog.component.html',
  styleUrl: './document-view-dialog.component.css'
})
export class DocumentViewDialogComponent {
  @Input() chatMessage?: ChatMessage;
  @Input() isDialogVisible: boolean = false;
  @Output() dialogClosed = new EventEmitter<void>();

  imageMessage: ChatMessageType = ChatMessageType.Image;
  videoMessage: ChatMessageType = ChatMessageType.Video;
  fileMessage: ChatMessageType = ChatMessageType.File;

  url?: string;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['chatMessage']) {
      this.url = this.chatMessage?.content?.toString();
    }
  }

  onCloseDialog() {
    this.dialogClosed.emit();
  }

  checkIfDocumentIsWord = checkIfDocumentIsWord;
}