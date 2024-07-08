import { FrequentlyAskedQuestion } from "../models/frequently-asked-question";
import { FreelancerDto } from "./freelancer-dto";
import { GetProjectFeatureResponse } from "./get-project-feature-response";
import { GetProjectReviewDto } from "./get-project-review-dto";

export interface GetProjectResponse{
    id: string,
    title: string,
    description: string,
    hasPackages: boolean, 
    features: GetProjectFeatureResponse[],
    frequentlyAskedQuestions: FrequentlyAskedQuestion[],
    pictures: string[],
    video: string,
    documents: string[],
    freelancer: FreelancerDto,
    reviews: GetProjectReviewDto[]
}