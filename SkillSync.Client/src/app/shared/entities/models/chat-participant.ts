import { User } from "./user";

export interface ChatParticipant extends User{
    isActive: boolean;  
}