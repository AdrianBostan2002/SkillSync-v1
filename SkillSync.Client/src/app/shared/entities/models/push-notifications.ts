import { Notification } from "./notification";

export interface PushNotifications {
    name: string;
    email: string;
    profilePicture: string;
    activityNotifications: Notification[];
    inboxNotifications: Notification[];
}