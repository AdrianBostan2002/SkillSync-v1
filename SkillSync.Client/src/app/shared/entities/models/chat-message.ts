import { ChatMessageType } from "../../enums/chat-message-type";

export interface ChatMessage {
    id: string;
    content: string | File;
    sender: string;
    wasMessageSentSuccessfully?: boolean;
    sentAt: string;
    type: ChatMessageType;
    wasMediaReceivedFromStorage?: boolean;
    shouldDisplayDocument?: boolean;
}