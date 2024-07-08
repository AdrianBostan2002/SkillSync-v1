import { SkillSubcategory } from "./skill-subcategory";
import { SkillBase } from "./skillbase";

export interface SkillCategory extends SkillBase{
    skillSubcategories: SkillSubcategory[]
}