import { OrderContentType } from "../../enums/order-content-type";

export interface OrderContent {
    id: string;
    blobName?: string;
    content: string;
    file?: File;
    description?: string;
    type: OrderContentType;
}