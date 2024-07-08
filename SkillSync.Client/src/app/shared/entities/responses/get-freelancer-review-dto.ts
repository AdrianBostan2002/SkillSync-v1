import { GetProjectReviewDto } from "./get-project-review-dto";

export interface GetFreelancerReviewDto extends GetProjectReviewDto {
    projectId: string;
}