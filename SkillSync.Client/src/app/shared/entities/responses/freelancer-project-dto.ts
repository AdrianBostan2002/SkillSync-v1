export interface FreelancerProjectDto {
    id: string;
    picture?: string;
    title: string;
    createdAt: Date;
    basicPrice?: number;
    standardPrice?: number;
    premiumPrice?: number;
}