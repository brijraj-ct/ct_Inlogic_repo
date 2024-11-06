using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Registration_Demo.Infrastructure.Models
{
    public class Coupons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CouponCode { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
