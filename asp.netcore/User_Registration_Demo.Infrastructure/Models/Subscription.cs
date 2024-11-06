using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User_Registration_Demo.Infrastructure.Models
{
    public class Subscription
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PackageType PackageType { get; set; }
        public decimal PackageCost { get; set; }
        public decimal PackageDiscount { get; set; }
    }

    public enum PackageType
    {
        Monthly,
        Annual
    }
}
