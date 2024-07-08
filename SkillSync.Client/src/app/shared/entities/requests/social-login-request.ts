import { SocialProvider } from "../../enums/social-provider";

export interface SocialLoginRequest{
    authorizationCode: string,
    socialProvider: SocialProvider
}