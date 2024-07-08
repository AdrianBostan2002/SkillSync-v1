import { FrequentlyAskedQuestion } from "../models/frequently-asked-question";
import { ProjectFeature } from "../models/project-option";

export class PostProjectRequest {
    skillId: string = "";
    title: string = "";
    description: string = "";
    hasPackages: boolean = false;
    features: ProjectFeature[] = [];
    frequentlyAskedQuestions: FrequentlyAskedQuestion[] = [];
    uploadedPictures: File[] = [];
    uploadedVideo?: File;
    uploadedDocuments: File[] = [];
}