import { Skill } from "./skill";
import { SkillBase } from "./skillbase";

export interface SkillSubcategory extends SkillBase{
    skills: Skill[]
}