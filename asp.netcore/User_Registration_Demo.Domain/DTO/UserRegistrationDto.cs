using System.ComponentModel.DataAnnotations;

namespace User_Registration_Demo.Domain.DTO
{
    public class UserRegistrationDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string? ConfirmPassword { get; set; }
        public int SubscriptionId { get; set; }
        public int NumberOfBranches { get; set; }
        public bool PaymentStatus { get; set; }
        public decimal SubscriptionAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
