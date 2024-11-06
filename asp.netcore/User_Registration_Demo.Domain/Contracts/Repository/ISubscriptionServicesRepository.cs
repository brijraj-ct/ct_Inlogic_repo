using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubscriptionServicesRepository
    {
        #region Subscription Repository Contracts
        /// <summary>
        /// Gets all subscriptions repository.
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto<List<SubscriptionDto>>> GetAllSubscriptions();
        /// <summary>
        /// Validates the coupon repository.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        Task<ResponseDto<CouponDto>> ValidateCoupon(string couponCode);
        #endregion
    }
}
