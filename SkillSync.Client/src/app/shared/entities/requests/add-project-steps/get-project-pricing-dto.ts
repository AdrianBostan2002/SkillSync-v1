import { GetProjectFeatureResponse } from "../../responses/get-project-feature-response"

export interface GetProjectPricingDto {
    hasPackages: boolean,
    features:
    {
        [id: string]: GetProjectFeatureResponse;
    }
}