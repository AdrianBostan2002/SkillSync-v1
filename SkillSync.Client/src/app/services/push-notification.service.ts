import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { Notification } from '../shared/entities/models/notification';
import { PushNotifications } from '../shared/entities/models/push-notifications';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PushNotificationService {

  newNotificationReceived$ = new Subject<Notification>();
  allNotificationsReceived$ = new Subject<PushNotifications[]>();

  connectionUrl = `${environment.apiUrl}notification`;

  private hubConnection?: signalR.HubConnection;

  public startConnection = (email: string): Promise<void> => {
    let url = `${this.connectionUrl}?user=${email}`;
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
          if (error) {
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

  public getPushNotifications(email: string) {
    this.hubConnection?.send("GetUserPushNotifications", email);
  }

  public setNotificationAsRead(notificationId: string) {
    this.hubConnection?.send("SetNotificationAsRead", notificationId);
  }

  public addChatListener = () => {
    this.hubConnection?.on('ReceiveNotification', (notification: Notification) => {
      this.newNotificationReceived$.next(notification);
    });

    this.hubConnection?.on('ReceiveAllNotifications', (allPushNotifications: PushNotifications[]) => {
      this.allNotificationsReceived$.next(allPushNotifications);
    });
  };
}