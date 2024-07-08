import { FeatureInputType } from "../../enums/feature-input-type";
import { DropdownOption } from "./dropdown-option";

export interface Feature {
    id: string,
    name: string,
    inputType: FeatureInputType,
    dropdownOptionId?: string
    dropdownOption?: DropdownOption,
}