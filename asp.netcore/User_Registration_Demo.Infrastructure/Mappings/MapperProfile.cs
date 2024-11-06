using AutoMapper;
using User_Registration_Demo.Domain.DTO;
using User_Registration_Demo.Infrastructure.Models;

namespace User_Registration_Demo.Infrastructure.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MapperProfile : Profile
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperProfile"/> class.
        /// </summary>
        public MapperProfile()
        {
            CreateMap<UserRegistrationDto, Users>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.PhoneNumber,opt=> opt.MapFrom(x=> x.Phone));

            CreateMap<SubscriptionDto, Subscription>().ReverseMap();
            CreateMap<SubscriptionFeaturesDto, SubscriptionFeatures>().ReverseMap();

            CreateMap<CouponDto, Coupons>().ReverseMap();
            CreateMap<UserSubscriptionDto, UserSubscriptions>().ReverseMap();
        }
        #endregion
    }
}
