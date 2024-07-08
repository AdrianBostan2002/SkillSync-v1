import { RoleType } from "../../enums/role-type";

export interface OwnSysRegisterRequest{
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    countryCode: string;
    role: RoleType;
    profilePicture: File;
}