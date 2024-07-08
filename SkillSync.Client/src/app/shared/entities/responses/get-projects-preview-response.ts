import { ReviewStatisticsDto } from "./review-statistics-dto";

export interface GetProjectPreviewResponse {
    id: string;
    freelancerId: string;
    freelancerProfilePicture: string;
    freelancerName: string;
    title: string;
    price: number;
    pictures: string[];
    video: string;
    showButtons?: boolean;
    pictureIndex?: number;
    isUserWhoMadeRequestFavorite?: boolean;
    reviewStatistics?: ReviewStatisticsDto;
}