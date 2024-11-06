using System.ComponentModel.DataAnnotations;

namespace User_Registration_Demo.Domain.DTO
{
    public class SubscriptionDto
    {
        public int? Id { get; set; }
        public string? PackageType { get; set; }
        public decimal PackageCost { get; set; }
        public decimal PackageDiscount { get; set; }
        public List<SubscriptionFeaturesDto>? SubscriptionFeaturesList { get; set; }
    }
}
