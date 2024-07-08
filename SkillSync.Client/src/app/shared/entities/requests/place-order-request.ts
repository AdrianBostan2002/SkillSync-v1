import { PackageType } from "../../enums/packages";

export interface PlaceOrderRequest {
    projectID: string;
    packageType: PackageType;
    createdAt: string;
    untilTo: string;
}