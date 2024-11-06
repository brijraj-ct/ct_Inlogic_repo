using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User_Registration_Demo.Infrastructure.Models;

namespace User_Registration_Demo.Infrastructure.Context
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext&lt;User_Registration_Demo.Infrastructure.Models.Users&gt;" />
    public class UserRegistrationContext : IdentityDbContext<Users>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrationContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext" />.</param>
        public UserRegistrationContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region DbSet Entities
        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public DbSet<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// Gets or sets the subscription features.
        /// </summary>
        /// <value>
        /// The subscription features.
        /// </value>
        public DbSet<SubscriptionFeatures> SubscriptionFeatures { get; set; }
        /// <summary>
        /// Gets or sets the coupons.
        /// </summary>
        /// <value>
        /// The coupons.
        /// </value>
        public DbSet<Coupons> Coupons { get; set; }
        /// <summary>
        /// Gets or sets the user subscriptions.
        /// </summary>
        /// <value>
        /// The user subscriptions.
        /// </value>
        public DbSet<UserSubscriptions> UserSubscriptions { get; set; }
        #endregion

        #region On Model Creating Method
        /// <summary>
        /// Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            base.OnModelCreating(builder);

            SeedSubscriptions(builder);

            SeedSubscriptionFeatures(builder);

            SeedCoupons(builder);
        }
        #endregion

        #region Private seeder methods

        /// <summary>
        /// Seeds the subscriptions.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void SeedSubscriptions(ModelBuilder builder)
        {
            builder.Entity<Subscription>().HasData(
                new Subscription { Id = 1, PackageType = PackageType.Monthly, PackageCost = 20.00m, PackageDiscount = 0 },
                new Subscription { Id = 2, PackageType = PackageType.Annual, PackageCost = 20.00m, PackageDiscount = 20 }
            );
        }

        /// <summary>
        /// Seeds the subscription features.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void SeedSubscriptionFeatures(ModelBuilder builder)
        {
            var features = new[]
            {
                new SubscriptionFeatures { Id = 1, FeatureName = "Advance analytics", SubscriptionId = 2 },
                new SubscriptionFeatures { Id = 2, FeatureName = "Mobile app access", SubscriptionId = 2 },
                new SubscriptionFeatures { Id = 3, FeatureName = "Real-time updates and notifications", SubscriptionId = 2 },
                new SubscriptionFeatures { Id = 4, FeatureName = "Up to 500 students", SubscriptionId = 2 },
                new SubscriptionFeatures { Id = 5, FeatureName = "Multiple school branches", SubscriptionId = 2 },
                new SubscriptionFeatures { Id = 6, FeatureName = "Advance analytics", SubscriptionId = 1 },
                new SubscriptionFeatures { Id = 7, FeatureName = "Mobile app access", SubscriptionId = 1 }
            };

            builder.Entity<SubscriptionFeatures>().HasData(features);
        }

        /// <summary>
        /// Seeds the coupons.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void SeedCoupons(ModelBuilder builder)
        {
            var coupons = new[]
            {
                new Coupons { Id = 1, CouponCode = "2024-JAN-1", DiscountPercentage = 10 },
                new Coupons { Id = 2, CouponCode = "2024-FEB-1", DiscountPercentage = 15 },
                new Coupons { Id = 3, CouponCode = "2024-MAR-1", DiscountPercentage = 20 },
                new Coupons { Id = 4, CouponCode = "2024-APR-1", DiscountPercentage = 25 },
                new Coupons { Id = 5, CouponCode = "2024-MAY-1", DiscountPercentage = 30 }
            };

            builder.Entity<Coupons>().HasData(coupons);
        }
        #endregion
    }


}
