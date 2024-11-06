namespace User_Registration_Demo.Domain.DTO
{
    public class UserSubscriptionDto
    {
        public string UserId { get; set; }
        public int SubscriptionId { get; set; }
        public int NumberOfBranches { get; set; }
        public bool PaymentStatus { get; set; }
        public decimal SubscriptionAmount{ get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
