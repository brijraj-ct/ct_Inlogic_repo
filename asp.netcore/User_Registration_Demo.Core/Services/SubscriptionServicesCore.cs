using User_Registration_Demo.Domain.Contracts.Core;
using User_Registration_Demo.Domain.Contracts.Repository;
using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="User_Registration_Demo.Domain.Contracts.Core.ISubscriptionServicesCore" />
    public class SubscriptionServicesCore : ISubscriptionServicesCore
    {
        #region Private variables
        /// <summary>
        /// The subscription services repository
        /// </summary>
        private readonly ISubscriptionServicesRepository _subscriptionServicesRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionServicesCore"/> class.
        /// </summary>
        /// <param name="subscriptionServicesRepository">The subscription services repository.</param>
        public SubscriptionServicesCore(ISubscriptionServicesRepository subscriptionServicesRepository)
        {
            _subscriptionServicesRepository = subscriptionServicesRepository;
        }
        #endregion

        #region Services
        /// <summary>
        /// Gets all subscriptions core.
        /// </summary>
        /// <returns></returns>
        public Task<ResponseDto<List<SubscriptionDto>>> GetAllSubscriptions() => _subscriptionServicesRepository.GetAllSubscriptions();

        /// <summary>
        /// Validates the coupon core.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        public Task<ResponseDto<CouponDto>> ValidateCoupon(string couponCode) => _subscriptionServicesRepository.ValidateCoupon(couponCode);
        #endregion
    }
}
