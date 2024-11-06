export interface SubscriptionDto {
    id?: number;
    packageType?: string;
    packageCost?: number;
    packageDiscount?: number;
    subscriptionFeaturesList?: SubscriptionFeaturesDto[];
    numberOfBranches?: number;
}

export interface SubscriptionFeaturesDto {
    featureName: string;
}