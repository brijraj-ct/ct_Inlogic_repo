export interface UsersDto {
    firstName: string; 
    lastName: string; 
    email: string; 
    phone?: string; 
    gender: string; 
    password: string; 
    confirmPassword?: string; 
    subscriptionId: any;
    numberOfBranches: any;
    paymentStatus: boolean;
    subscriptionAmount?: number;
    discountAmount?: number;
    totalAmount?: number;
}