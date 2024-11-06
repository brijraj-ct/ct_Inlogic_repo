using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Registration_Demo.Infrastructure.Models
{
    public class UserSubscriptions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SubscriptionId { get; set; }
        public int NumberOfBranches { get; set; }
        public bool PaymentStatus { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        [ForeignKey("SubscriptionId")]
        public Subscription Subscription { get; set; }
        public decimal SubscriptionAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
