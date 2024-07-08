import { OrderStatus } from "../../enums/order-status";

export interface OrderPreviewDto {
    id: string;
    projectId: string;
    projectTitle: string;
    name: string;
    email: string;
    status: OrderStatus;
    price: number;
    createdAt: Date;
    untilTo: Date;
    completedAt?: Date;
}