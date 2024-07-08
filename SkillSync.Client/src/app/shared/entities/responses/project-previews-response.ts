import { GetProjectPreviewResponse } from "./get-projects-preview-response";

export interface ProjectPreviewResponse {
    projects: GetProjectPreviewResponse[];
    totalProjectsCount: number;
}