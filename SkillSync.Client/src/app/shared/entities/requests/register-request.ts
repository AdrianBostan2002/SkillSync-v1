import { RoleType } from "../../enums/role-type";
import { SocialProvider } from "../../enums/social-provider";

export interface SocialProviderRegisterRequest {
    socialProvider: SocialProvider;
    accessToken: string;   
    role: RoleType;
}