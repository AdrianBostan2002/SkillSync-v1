import { ChatMessage } from "./chat-message";
import { ChatParticipant } from "./chat-participant";

export interface Chat{
    id? : string;
    messages : ChatMessage[];
    otherParticipant : ChatParticipant;
    hasUnseenMessages : boolean;
}