import { Skill } from "../models/skill";

export interface CompleteFreelancerExperienceRequest{
    skills: Skill[],
    scopeDescription: string
}