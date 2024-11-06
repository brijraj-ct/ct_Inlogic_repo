using AutoMapper;
using Microsoft.EntityFrameworkCore;
using User_Registration_Demo.Domain.Contracts.Repository;
using User_Registration_Demo.Domain.DTO;
using User_Registration_Demo.Infrastructure.Context;

namespace User_Registration_Demo.Infrastructure.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="User_Registration_Demo.Domain.Contracts.Repository.ISubscriptionServicesRepository" />
    public class SubscriptionServicesRepository : ISubscriptionServicesRepository
    {
        #region Private variables
        /// <summary>
        /// The user registration context
        /// </summary>
        private readonly UserRegistrationContext _userRegistrationContext;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionServicesRepository"/> class.
        /// </summary>
        /// <param name="userRegistrationContext">The user registration context.</param>
        /// <param name="mapper">The mapper.</param>
        public SubscriptionServicesRepository(UserRegistrationContext userRegistrationContext, IMapper mapper)
        {
            _userRegistrationContext = userRegistrationContext;
            _mapper = mapper;
        }
        #endregion

        #region Subscription Repository Services
        /// <summary>
        /// Gets all subscriptions repository.
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<List<SubscriptionDto>>> GetAllSubscriptions()
        {
            var response = new ResponseDto<List<SubscriptionDto>>();
            var subscriptions = _mapper.Map<List<SubscriptionDto>>(await _userRegistrationContext.Subscriptions.ToListAsync());
            foreach (var item in subscriptions)
            {
                var features = _mapper.Map<List<SubscriptionFeaturesDto>>(await _userRegistrationContext.SubscriptionFeatures.Where(x => x.SubscriptionId == item.Id).ToListAsync());
                if(features.Count > 0)
                {
                    item.SubscriptionFeaturesList = [.. features];
                }
            }
            response.Data = subscriptions;
            response.Success = true;
            return response;
        }

        /// <summary>
        /// Validates the coupon repository.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        public async Task<ResponseDto<CouponDto>> ValidateCoupon(string couponCode)
        {
            var response = new ResponseDto<CouponDto>();
            response.Data = _mapper.Map<CouponDto>(await _userRegistrationContext.Coupons.FirstOrDefaultAsync(x => x.CouponCode == couponCode));
            if (response.Data == null)
            {
                response.Success = false;
                response.Message = "Invalid Coupon Code";
            }
            else
            {
                response.Success = true;
                response.Message = "Coupon Code Applied";
            }
            return response;
        } 
        #endregion
    }
}
