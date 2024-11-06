using AutoMapper;
using Microsoft.AspNetCore.Identity;
using User_Registration_Demo.Domain.Contracts.Repository;
using User_Registration_Demo.Domain.DTO;
using User_Registration_Demo.Domain.Helpers;
using User_Registration_Demo.Infrastructure.Context;
using User_Registration_Demo.Infrastructure.Models;

namespace User_Registration_Demo.Infrastructure.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="User_Registration_Demo.Domain.Contracts.Repository.IUserServicesRepository" />
    public class UserServicesRepository : IUserServicesRepository
    {
        #region Private variables
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<Users> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<Users> _signInManager;
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
        /// Initializes a new instance of the <see cref="UserServicesRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="userRegistrationContext">The user registration context.</param>
        public UserServicesRepository(UserManager<Users> userManager, IMapper mapper, SignInManager<Users> signInManager, UserRegistrationContext userRegistrationContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _userRegistrationContext = userRegistrationContext;
        }
        #endregion

        #region User Repository Services
        /// <summary>
        /// Logins the user asynchronous repository.
        /// </summary>
        /// <param name="userLoginDto">The user login dto.</param>
        /// <returns></returns>
        public async Task<ResponseDto<bool>> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var response = new ResponseDto<bool>();

            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                response.Message = Constants.LoginEmailFailedMessage;
                return response;
            }

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (!isCorrectPassword)
            {
                response.Message = Constants.LoginPasswordFailedMessage;
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, isPersistent: false, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                response.Success = true;
                response.Message = Constants.LoginSuccessMessage;
            }
            else
            {
                response.Success = false;
                response.Message = Constants.LoginFailureMessage;
            }
            
            return response;
        }

        /// <summary>
        /// Registers the user asynchronous repository.
        /// </summary>
        /// <param name="userRegistrationDto">The user registration dto.</param>
        public async Task<ResponseDto<UserRegistrationDto>> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            var response = new ResponseDto<UserRegistrationDto>();
            var user = _mapper.Map<Users>(userRegistrationDto);
            var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);
            if (result.Succeeded)
            {
                UserSubscriptionDto userSubscriptionDto = new UserSubscriptionDto
                {
                    UserId = user.Id,
                    SubscriptionId = userRegistrationDto.SubscriptionId,
                    NumberOfBranches = userRegistrationDto.NumberOfBranches,
                    PaymentStatus = userRegistrationDto.PaymentStatus,
                    SubscriptionAmount = userRegistrationDto.SubscriptionAmount,
                    TotalAmount = userRegistrationDto.TotalAmount,
                    DiscountAmount = userRegistrationDto.DiscountAmount
            };
                var userSubs = _mapper.Map<UserSubscriptions>(userSubscriptionDto);
                
                await _userRegistrationContext.UserSubscriptions.AddAsync(userSubs);
                await _userRegistrationContext.SaveChangesAsync();
                response.Success = true;
                response.Data = userRegistrationDto;
                response.Message = Constants.RegisterSuccessMessage;
            }
            else
            {
                response.Success = false;
                response.Message = Constants.RegisterFailedMessage;
                response.Errors = result.Errors.Select(e => e.Description).ToList();
            }
            return response;
        }
        #endregion
    }
}
