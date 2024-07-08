import { GetFreelancerReviewDto } from "./get-freelancer-review-dto";
import { ProjectReviewDataDto } from "./project-review-data-dto";
import { ReviewStatisticsDto } from "./review-statistics-dto";

export interface FreelancerReviewsDto {
    usersProfilePicture: { [key: string]: string };
    projects: { [key: string]: ProjectReviewDataDto };
    reviews: GetFreelancerReviewDto[];
    reviewStatistics: ReviewStatisticsDto;
}