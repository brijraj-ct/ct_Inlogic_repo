using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Domain.Contracts.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubscriptionServicesCore
    {
        #region Subscription Core Contracts
        /// <summary>
        /// Gets all subscriptions core.
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<List<SubscriptionDto>>> GetAllSubscriptions();
        /// <summary>
        /// Validates the coupon core.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        Task<ResponseDto<CouponDto>> ValidateCoupon(string couponCode);
        #endregion
    }
}
