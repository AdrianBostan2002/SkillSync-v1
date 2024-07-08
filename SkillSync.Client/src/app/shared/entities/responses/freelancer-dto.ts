import { User } from "../models/user";
import { FreelancerReviewsDto } from "./freelancer-reviews-dto";
import { FreelancerSkillsDto } from "./freelancer-skills-dto";
import { GetProjectPreviewResponse } from "./get-projects-preview-response";

export interface FreelancerDto extends User {
    id: string,
    description: string,
    countryCode: string,
    skills: FreelancerSkillsDto[],
    projects: GetProjectPreviewResponse[],
    reviews: FreelancerReviewsDto
}