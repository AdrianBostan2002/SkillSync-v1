import { FeatureOptionBase } from "./feature-option-base";

export interface DropdownOption extends FeatureOptionBase<number> {
  id: string;
  lowerInterval: number;
  upperInterval: number;
  incrementValue: number;
  values: number[]
}