namespace User_Registration_Demo.Domain.DTO
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string? CouponCode { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
