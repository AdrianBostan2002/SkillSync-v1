export interface FeatureOptionBase<T>{
    name?: string,
    featureId?: string
    basicSelectedValue: T,
    standardSelectedValue: T,
    premiumSelectedValue: T,
    defaultValue?: T
}