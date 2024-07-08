import { OrderStatus } from "../../enums/order-status";
import { PackageType } from "../../enums/packages";
import { OrderContent } from "./order-content";

export interface Order {
    id: string;
    projectId: string;
    projectTitle: string;
    customerName: string;
    customerEmail: string;
    freelancerName: string;
    freelancerId: string;
    price: number;
    packageType: PackageType;
    status: OrderStatus;
    createdAt: Date;
    untilTo: Date;
    completedAt?: Date;
    previewContents: OrderContent[];
    finalProductContents: OrderContent[];
}