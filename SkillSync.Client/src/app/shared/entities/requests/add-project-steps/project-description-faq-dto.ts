import { FrequentlyAskedQuestion } from "../../models/frequently-asked-question";

export interface ProjectDescriptionFaqDto{
    description: string,
    frequentlyAskedQuestions: FrequentlyAskedQuestion[],
    wasAnyQuestionModified?: boolean
}