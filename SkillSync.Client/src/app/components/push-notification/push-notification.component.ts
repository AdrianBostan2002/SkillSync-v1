import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { PushNotificationService } from '../../services/push-notification.service';
import { NotificationType } from '../../shared/enums/notification-type';
import { Notification } from '../../shared/entities/models/notification';
import { PushNotifications } from '../../shared/entities/models/push-notifications';
import { User } from '../../shared/entities/models/user';
import { ChatService } from '../../services/chat.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-push-notification',
  templateUrl: './push-notification.component.html',
  styleUrl: './push-notification.component.css'
})
export class PushNotificationComponent {
  private messageSeenSubscription?: Subscription;

  countOfUnReadInboxNotifications?: number;
  countOfUnReadActivityNotifications?: number;

  constructor
    (
      private router: Router,
      private tokenService: TokenService,
      private pushNotificationService: PushNotificationService,
      private chatService: ChatService
    ) { }

  inboxNotifications: Notification[] = [];
  activityNotifications: Notification[] = [];

  ngOnInit() {
    this.messageSeenSubscription = this.chatService.messageSeen$.subscribe((senderEmail) => {
      const foundNotification = this.inboxNotifications.find((notification) => notification.email == senderEmail);
      if (foundNotification) {
        this.setNotificationAsRead(foundNotification);
      }
    });

    let userEmail = this.tokenService.getEmail();
    if (userEmail) {
      this.pushNotificationService.startConnection(userEmail).then(() => {
        this.pushNotificationService.getPushNotifications(userEmail ?? "");
        this.pushNotificationService.addChatListener();
        this.addSubscribe();
      });
    }
  }

  private addSubscribe() {
    this.pushNotificationService.allNotificationsReceived$.subscribe((allPushNotifications) => {
      allPushNotifications.forEach((pushNotification) => {
        pushNotification.inboxNotifications.forEach((notification) => {
          this.mapNotifications(pushNotification, notification, this.inboxNotifications, true);
        });
        this.inboxNotifications = [...this.inboxNotifications.sort((a, b) => new Date(b.sentAt).getTime() - new Date(a.sentAt).getTime())];
        pushNotification.activityNotifications.forEach((notification) => {
          this.mapNotifications(pushNotification, notification, this.activityNotifications, false);
        });
        this.activityNotifications = [...this.activityNotifications.sort((a, b) => new Date(b.sentAt).getTime() - new Date(a.sentAt).getTime())];
      });
    });

    this.pushNotificationService.newNotificationReceived$.subscribe((notification) => {
      if (notification.type == NotificationType.NewMessage) {
        this.inboxNotifications.unshift(notification);
        this.countOfUnReadInboxNotifications = this.countOfUnReadInboxNotifications ? this.countOfUnReadInboxNotifications + 1 : 1;
      }
      else {
        this.activityNotifications.unshift(notification);
        this.countOfUnReadActivityNotifications = this.countOfUnReadActivityNotifications ? this.countOfUnReadActivityNotifications + 1 : 1;
      }
    });
  }

  mapNotifications(pushNotification: PushNotifications, notification: Notification, notificationContainer: Notification[], isInboxNotification: boolean) {
    notification.email = pushNotification.email;
    notification.name = pushNotification.name;
    notification.profilePicture = pushNotification.profilePicture;
    notificationContainer.push(notification);
    if (!notification.isRead) {
      if (isInboxNotification) {
        this.countOfUnReadInboxNotifications = this.countOfUnReadInboxNotifications ? this.countOfUnReadInboxNotifications + 1 : 1;
      }
      else {
        this.countOfUnReadActivityNotifications = this.countOfUnReadActivityNotifications ? this.countOfUnReadActivityNotifications + 1 : 1;
      }
    }
  }

  onNavigateToChatClick() {
    this.router.navigate(['/chat']);
  }

  onInboxNotificationSelected(notification: Notification) {
    this.router.navigate(['/chat'], { state: { toUser: notification as User } });
  }

  setNotificationAsRead(notification: Notification) {
    if (!notification.isRead) {
      this.pushNotificationService.setNotificationAsRead(notification.id);
      notification.isRead = true;

      this.decrementUnReadNotificationCounter(notification);
    }
    else if (notification.type == NotificationType.PlacedOrder || notification.type == NotificationType.OrderStatusChanged || notification.type == NotificationType.PreviewContentModified) {
      this.router.navigate(['/order'], { state: { orderId: notification.additionalData } });
    }
  }

  private decrementUnReadNotificationCounter(notification: Notification) {
    if (notification.type == NotificationType.NewMessage) {
      this.countOfUnReadInboxNotifications = this.countOfUnReadInboxNotifications ? this.countOfUnReadInboxNotifications - 1 : 0;
    }
    else {
      this.countOfUnReadActivityNotifications = this.countOfUnReadActivityNotifications ? this.countOfUnReadActivityNotifications - 1 : 0;
    }
  }

  ngOnDestroy() {
    this.pushNotificationService.stopConnection();
    this.messageSeenSubscription?.unsubscribe();
  }
}
