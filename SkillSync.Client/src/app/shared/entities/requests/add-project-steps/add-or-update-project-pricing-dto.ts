import { ProjectFeature } from "../../models/project-option";

export interface AddOrUpdateProjectPricingDto {
    hasPackages: boolean;
    features: ProjectFeature[];
}