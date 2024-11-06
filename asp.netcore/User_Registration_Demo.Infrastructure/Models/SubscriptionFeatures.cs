using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Registration_Demo.Infrastructure.Models
{
    public class SubscriptionFeatures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FeatureName { get; set; }
        public int SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        public Subscription? Subscription { get; set; }
    }
}
