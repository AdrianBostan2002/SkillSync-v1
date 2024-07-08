import { ChangeDetectorRef, Component, ElementRef, QueryList, TemplateRef, ViewChild, ViewChildren } from '@angular/core';
import { Chat } from '../../shared/entities/models/chat';
import { ChatService } from '../../services/chat.service';
import { TokenService } from '../../services/token.service';
import { ChatMessage } from '../../shared/entities/models/chat-message';
import { appendFileExtension, checkIfDocumentIsWord, downloadBlob, extractFirstName, generateTempId, getDocumentFileTypeRestrictions, getPictureFileTypeRestrictions, getVideoFileTypeRestrictions } from '../../shared/utils';
import { ChatParticipant } from '../../shared/entities/models/chat-participant';
import { User } from '../../shared/entities/models/user';
import { ChatMessageType } from '../../shared/enums/chat-message-type';
import { FileUploadEvent } from 'primeng/fileupload';
import { UploadedFile } from '../../shared/entities/models/uploaded-files';
import { FileType } from '../../shared/enums/file-type';
import { DatePipe } from '@angular/common';
import { Subscription } from 'rxjs';
import { ChatbotService } from '../../services/chatbot.service';

@Component({
  selector: 'app-chat-page',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss'
})
export class ChatPageComponent {
  private chatSubscription?: Subscription;
  private newChatRoomInitiatedSubscription?: Subscription;
  private receivedMessageSubscription?: Subscription;
  private messageIdSentSuccessfullySubscription?: Subscription;
  private userChatsSubscription?: Subscription;

  currentUser?: string | null;
  currentUserFirstName?: string;
  inputMessage?: string;

  toUser?: User;

  currentChat?: Chat;
  currentChatParticipant?: ChatParticipant;

  userChats?: Chat[];
  filteredChats?: Chat[];
  chatFilterInput: string = "";

  textMessage: ChatMessageType = ChatMessageType.Text;
  imageMessage: ChatMessageType = ChatMessageType.Image;
  videoMessage: ChatMessageType = ChatMessageType.Video;
  fileMessage: ChatMessageType = ChatMessageType.File;

  @ViewChildren("chatHistory") chatHistory: QueryList<ElementRef> | undefined;

  constructor
    (
      private tokenService: TokenService,
      private chatService: ChatService,
      private elRef: ElementRef,
      private chatBotService: ChatbotService,
      private cdf: ChangeDetectorRef,
      public datepipe: DatePipe
    ) { }

  ngOnInit() {
    this.chatBotService.visibility$.next(false);
    this.addSubscribe();

    this.currentUser = this.tokenService.getEmail();
    this.currentUserFirstName = extractFirstName(this.tokenService.getUsername() ?? "");
    this.toUser = history.state.toUser;

    if (this.currentUser) {
      this.startConnection(this.currentUser)
        .then(() => {
          this.chatService.getUserChats(this.currentUser ?? "");
          if (this.toUser) {
            this.chatService.getChatRoom(this.currentUser ?? "", this.toUser.email);
          }
        });
    }
  }

  onChatChanged(chat: Chat) {
    this.currentChat = chat;

    if (this.currentUser && this.currentChat && this.currentChat.id == undefined) {
      this.chatService.getChatRoom(this.currentUser, this.currentChat.otherParticipant.email);
    }

    if (chat.hasUnseenMessages) {
      this.chatService.messageSeen$.next(chat.otherParticipant.email);
      chat.hasUnseenMessages = false;
    }

    this.scrollToBottom();
  }

  private addSubscribe() {
    this.chatSubscription = this.chatService.chat$.subscribe((chatRoom) => {
      this.currentChat = chatRoom;

      this.userChats = this.userChats?.filter(chat => chat.otherParticipant.email != chatRoom.otherParticipant.email);
      this.userChats?.unshift(chatRoom);
      this.filteredChats = this.userChats;
    });

    this.newChatRoomInitiatedSubscription = this.chatService.newChatRoomInitiated$.subscribe((chatRoom) => {
      this.userChats?.push(chatRoom);
    });

    this.receivedMessageSubscription = this.chatService.receivedMessage$.subscribe((message) => {
      let messageChatRoom = this.userChats?.filter(chat => chat.otherParticipant.email == message.sender);
      if (messageChatRoom) {
        messageChatRoom[0].messages.push(message);
        messageChatRoom[0].otherParticipant.isActive = true;

        if (this.currentChat != messageChatRoom[0]) {
          messageChatRoom[0].hasUnseenMessages = true;
        }
      }
    });

    this.messageIdSentSuccessfullySubscription = this.chatService.messageIdSentSuccessfully$.subscribe((messageId) => {
      let message = this.currentChat?.messages.find(m => m.id == messageId);
      if (message) {
        message.wasMessageSentSuccessfully = true;
      }
    });

    this.userChatsSubscription = this.chatService.userChats$.subscribe((chats) => {
      this.userChats = chats;
      this.filteredChats = this.userChats;
    });
  }

  private startConnection(currentUsername: string): Promise<void> {
    return this.chatService.startConnection(currentUsername).then(() => {
      this.chatService.addChatListener();
    });
  }

  sendMessage() {
    if (this.lastUploadedFile && this.inputMessage == this.lastUploadedFile?.file?.name) {
      this.sendPictureMessage();
    }
    else if (this.currentChat && this.currentChat.id && this.currentUser && this.inputMessage && this.inputMessage.trim().length > 0) {
      let sendAt: string = this.datepipe.transform(new Date(), 'yyyy-MM-ddTHH:mm:ss') as string;
      let messageId: string = generateTempId();
      let newMessage: ChatMessage = { id: messageId, content: this.inputMessage, sender: this.currentUser, sentAt: sendAt, type: ChatMessageType.Text };
      this.chatService.sendTextMessage(this.currentChat.id, newMessage);
      this.currentChat?.messages.push(newMessage);
      this.inputMessage = "";
    }
    this.scrollToBottom();
  }

  fileTypeRestrictions?: string;
  private imageFileTypeRestrictions: string = getPictureFileTypeRestrictions();
  private videoFileTypeRestrictions: string = getVideoFileTypeRestrictions();
  private documentFileTypeRestrictions: string = getDocumentFileTypeRestrictions();

  lastUploadedFile?: UploadedFile;
  lastSelectedFileType?: FileType;

  async onUpload(event: FileUploadEvent) {
    let newFile: File = event.files[0];
    this.lastUploadedFile = { url: URL.createObjectURL(newFile), file: newFile, type: this.lastSelectedFileType };
    this.inputMessage = newFile.name;
  }

  triggerUploadPicture() {
    this.fileTypeRestrictions = this.imageFileTypeRestrictions;
    setTimeout(() => {
      const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-file-button input[type=file]');
      if (nativeInputFile) {
        this.lastSelectedFileType = FileType.Image;
        nativeInputFile.click();
      }
    }, 50);
  }

  triggerUploadVideo() {
    this.fileTypeRestrictions = this.videoFileTypeRestrictions;
    setTimeout(() => {
      const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-file-button input[type=file]');
      if (nativeInputFile) {
        this.lastSelectedFileType = FileType.Video;
        nativeInputFile.click();
      }
    }, 50);
  }

  triggerUploadDocument() {
    this.fileTypeRestrictions = this.documentFileTypeRestrictions;
    setTimeout(() => {
      const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-file-button input[type=file]');
      if (nativeInputFile) {
        this.lastSelectedFileType = FileType.Document;
        nativeInputFile.click();
      }
    }, 50);
  }

  async sendPictureMessage() {
    if (this.lastUploadedFile && this.inputMessage == this.lastUploadedFile?.file?.name && this.currentChat && this.currentUser) {
      let sendAt: string = this.datepipe.transform(new Date(), 'yyyy-MM-ddTHH:mm:ss') as string;
      let messageId: string = generateTempId();
      let messageType = this.lastUploadedFile.type == FileType.Image ? ChatMessageType.Image : ChatMessageType.Video;
      messageType = this.lastUploadedFile.type == FileType.Document ? ChatMessageType.File : messageType;

      let newMessage: ChatMessage = {
        id: messageId,
        content: this.lastUploadedFile.file ?? '',
        sender: this.currentUser ?? '',
        sentAt: sendAt,
        type: messageType
      };

      this.chatService.sendMediaMessage(this.currentChat?.id ?? '', newMessage);

      if (this.lastUploadedFile.file) {
        newMessage.content = URL.createObjectURL(this.lastUploadedFile.file);
        newMessage.wasMediaReceivedFromStorage = true;

        if (checkIfDocumentIsWord(this.lastUploadedFile.file.name)) {
          newMessage.content = this.appendFileExtension(newMessage.content as string, 'docx');
        }
      }

      this.currentChat?.messages.push(newMessage);
      this.inputMessage = "";
    }
  }

  async getMedia(message: ChatMessage) {
    let result = await this.chatService.getMediaMessage(message.content as string, message.type);

    message.content = result.result;
    message.wasMediaReceivedFromStorage = true;
  }

  extractFirstName = extractFirstName;

  async onDocumentSelected(message: ChatMessage) {
    let messageContent = message.content.toString();
    if (messageContent.includes("localhost") && messageContent.includes(".docx")) {
      messageContent = messageContent.replace(".docx", "");
      await this.downloadFile(messageContent, "file");
      return;
    }
    message.shouldDisplayDocument = !message.shouldDisplayDocument;
  }

  checkIfDocumentIsWord = checkIfDocumentIsWord;
  appendFileExtension = appendFileExtension;

  @ViewChild('getFromCloudPicture') getFromCloudPicture!: TemplateRef<any>;
  @ViewChild('getFromCloudVideo') getFromCloudVideo!: TemplateRef<any>;
  @ViewChild('getFromCloudPdfDocument') getFromCloudPdfDocument!: TemplateRef<any>;
  @ViewChild('getFromCloudWordDocument') getFromCloudWordDocument!: TemplateRef<any>;

  getTemplateBasedOnMessageType(message: ChatMessage) {
    if (message.type == this.imageMessage) {
      return this.getFromCloudPicture;
    } else if (message.type == this.videoMessage) {
      return this.getFromCloudVideo;
    } else if (message.type == this.fileMessage && !this.checkIfDocumentIsWord(message.content.toString())) {
      return this.getFromCloudPdfDocument;
    } else {
      return this.getFromCloudWordDocument;
    }
  }

  shouldDisplayDatetime(message: ChatMessage, index: number) {
    if (index == 0) {
      return true;
    }

    let previousMessage = this.currentChat?.messages[index - 1];
    if (previousMessage) {
      let previousMessageSentAt = new Date(previousMessage.sentAt);
      let currentMessageSentAt = new Date(message.sentAt);

      let diff = currentMessageSentAt.getTime() - previousMessageSentAt.getTime();
      if (diff > 1000 * 60 * 5) {
        return true;
      }
    }

    return false;
  }

  filterChats() {
    if (this.chatFilterInput != "") {
      this.filteredChats = this.userChats?.filter(chat => chat.otherParticipant.name.toLowerCase().includes(this.chatFilterInput.toLowerCase()));
    }
    else {
      this.filteredChats = this.userChats;
    }
  }

  downloadFile = downloadBlob;

  onDialogClosed(message: ChatMessage) {
    message.shouldDisplayDocument = false;
  }

  ngAfterContentChecked(): void {
    this.cdf.detectChanges();
  }

  private scrollToBottom(): void {
    setTimeout(() => {
      try {
        if (this.chatHistory && this.chatHistory.last && this.chatHistory.last.nativeElement) {
          this.chatHistory.last.nativeElement.scrollTop = this.chatHistory.last.nativeElement.scrollHeight;
        }
      } catch (err) {
        console.error('Could not scroll to bottom:', err);
      }
    }, 0);
  }

  ngOnDestroy() {
    this.chatBotService.visibility$.next(true);
    this.chatService.stopConnection();

    this.chatSubscription?.unsubscribe();
    this.newChatRoomInitiatedSubscription?.unsubscribe();
    this.receivedMessageSubscription?.unsubscribe();
    this.messageIdSentSuccessfullySubscription?.unsubscribe();
    this.userChatsSubscription?.unsubscribe();
  }
}