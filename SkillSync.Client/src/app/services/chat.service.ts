import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject, lastValueFrom } from 'rxjs';
import { ChatMessage } from '../shared/entities/models/chat-message';
import { Chat } from '../shared/entities/models/chat';
import { HttpClient } from '@angular/common/http';
import { buildRoute } from '../shared/utils';
import { ChatMessageType } from '../shared/enums/chat-message-type';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private httpClient: HttpClient) { }

  chat$ = new Subject<Chat>();
  receivedMessage$ = new Subject<ChatMessage>();
  messageIdSentSuccessfully$ = new Subject<string>();
  userChats$ = new Subject<Chat[]>();
  newChatRoomInitiated$ = new Subject<Chat>();
  messageSeen$ = new Subject<string>();

  connectionUrl = `${environment.apiUrl}chat`;

  private hubConnection?: signalR.HubConnection;

  public startConnection = (username: string): Promise<void> => {
    let url = `${this.connectionUrl}?user=${username}`;
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(url)
      .withAutomaticReconnect()
      .build();

    return new Promise<void>((resolve, reject) => {
      if (this.hubConnection) {
        this.hubConnection
          .start()
          .then(() => {
            console.log('Connection started');
            resolve();
          })
          .catch((error) => {
            console.error('Error while starting connection:', error);
            reject(error);
          });

        this.hubConnection.onclose((error) => {
          if(error){
            console.error('Connection closed with an error:', error);
          }
          reject(error);
        });
        this.hubConnection.onreconnecting((error) => {
          console.warn('Connection is reconnecting:', error);
        });
      }
    });
  };

  public stopConnection = () => {
    this.hubConnection?.stop();
  }

  public getChatRoom(senderEmail: string, receiverEmail: string) {
    this.hubConnection?.send("GetChatRoom", senderEmail, receiverEmail);
  }

  public sendTextMessage(chatRoomId: string, message: ChatMessage) {
    this.hubConnection?.send("SendTextMessage", chatRoomId, message);
  }

  public async sendMediaMessage(chatRoomId: string, message: ChatMessage) {
    const formData = new FormData();
    formData.append('id', message.id);
    if (message.content instanceof File) {
      formData.append('content', message.content, message.content.name);
    }
    formData.append('sender', message.sender);
    formData.append('sentAt', message.sentAt);
    formData.append('type', message.type.toString());

    let route = buildRoute(`api/Chat/send/${chatRoomId}`);

    let result = this.httpClient.post<any>(route, formData);

    return await lastValueFrom(result);
  }

  public async getMediaMessage(message: string, type: ChatMessageType) {
    let route = buildRoute(`api/Chat/media/${message}/${type}`);

    let result = this.httpClient.get<any>(route);

    return await lastValueFrom(result);
  }

  public async getDocumentMessage(message: string) {
    let route = buildRoute(`api/Chat/media/document/${message}`);

    let result = this.httpClient.get<any>(route);

    return await lastValueFrom(result);
  }

  public getUserChats(email: string) {
    this.hubConnection?.send("GetUserChats", email);
  }

  public addChatListener = () => {
    this.hubConnection?.on('MessageSentSuccessfully', (messageId) => {
      this.messageIdSentSuccessfully$.next(messageId);
    });

    this.hubConnection?.on('ReceiveMessage', (message: ChatMessage) => {
      this.receivedMessage$.next(message);
    });

    this.hubConnection?.on('ChatRoomCreated', (chat: Chat) => {
      this.chat$.next(chat);
    });

    this.hubConnection?.on('ReceiveAllUserChats', (chats: Chat[]) => {
      this.userChats$.next(chats);
    });

    this.hubConnection?.on('NewChatRoomInitiated', (chat: Chat) => {
      this.newChatRoomInitiated$.next(chat);
    });
  };

  public disconnectFromHub() {
    this.hubConnection?.stop();
  }
}
