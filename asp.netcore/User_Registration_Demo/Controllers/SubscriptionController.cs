using Microsoft.AspNetCore.Mvc;
using User_Registration_Demo.Domain.Contracts.Core;
using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        #region Private variables
        /// <summary>
        /// The subscription services core
        /// </summary>
        private readonly ISubscriptionServicesCore _subscriptionServicesCore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionController"/> class.
        /// </summary>
        /// <param name="subscriptionServicesCore">The subscription services core.</param>
        public SubscriptionController(ISubscriptionServicesCore subscriptionServicesCore)
        {
            _subscriptionServicesCore = subscriptionServicesCore;
        }
        #endregion

        #region APIs
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<ResponseDto<List<SubscriptionDto>>> GetAll() => await _subscriptionServicesCore.GetAllSubscriptions();

        /// <summary>
        /// Validates the coupon.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        [HttpPost("validateCoupon")]
        public async Task<ResponseDto<CouponDto>> ValidateCoupon(string couponCode) => await _subscriptionServicesCore.ValidateCoupon(couponCode);
        #endregion
    }
}
