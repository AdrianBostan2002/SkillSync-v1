import { NotificationType } from "../../enums/notification-type";
import { User } from "./user";

export interface Notification extends User {
    id: string;
    content: string;
    sentAt: Date;
    isRead: boolean;
    type: NotificationType;
    additionalData?: string;
}