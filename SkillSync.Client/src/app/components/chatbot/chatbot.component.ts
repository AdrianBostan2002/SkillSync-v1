import { Component, ElementRef, QueryList, ViewChildren } from '@angular/core';
import { ChatbotService } from '../../services/chatbot.service';
import { Subscription } from 'rxjs';
import { TokenService } from '../../services/token.service';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-chatbot',
  templateUrl: './chatbot.component.html',
  styleUrl: './chatbot.component.css'
})
export class ChatbotComponent {
  @ViewChildren("chatHistory") chatHistory: QueryList<ElementRef> | undefined;
  private visibilitySubscription?: Subscription;
  private authenticationServiceSubscription?: Subscription;

  isChatbotVisible: boolean = false;
  isButtonVisible: boolean = true;
  isQueryLoading: boolean = false;
  botPictureUrl: string = '../../../assets/img/fibo.jpg';
  defaultPofilePictureUrl = "assets/resources/no-user-profile-picture.png";

  chatMessage: string = '';

  messages: { isChatBotMessage: boolean, content: string }[] = [];

  constructor(
    private chatBotService: ChatbotService,
    private tokenService: TokenService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.defaultPofilePictureUrl = this.tokenService.getProfilePictureUrl() ?? "assets/resources/no-user-profile-picture.png";

    this.authenticationServiceSubscription = this.authenticationService.userLoggedIn.subscribe(status => {
      this.defaultPofilePictureUrl = this.tokenService.getProfilePictureUrl() ?? "assets/resources/no-user-profile-picture.png";
    });

    this.visibilitySubscription = this.chatBotService.visibility$.subscribe(visibility => {
      this.isButtonVisible = visibility;
    });
  }

  showChatbotDialog() {
    this.isChatbotVisible = !this.isChatbotVisible;
  }

  async sendMessage() {
    this.messages.push({ isChatBotMessage: false, content: this.chatMessage });

    let message = this.chatMessage;
    this.chatMessage = '';
    this.isQueryLoading = true;

    let response = await this.chatBotService.executeQuery(message);
    this.isQueryLoading = false;

    this.messages.push({ isChatBotMessage: true, content: response.result });

    this.scrollToBottom();
  }

  ngOnDestroy() {
    this.visibilitySubscription?.unsubscribe();
    this.authenticationServiceSubscription?.unsubscribe();
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
}