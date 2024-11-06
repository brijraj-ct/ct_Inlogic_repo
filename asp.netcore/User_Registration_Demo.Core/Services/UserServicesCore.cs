using User_Registration_Demo.Domain.Contracts.Core;
using User_Registration_Demo.Domain.Contracts.Repository;
using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="User_Registration_Demo.Domain.Contracts.Core.IUserServicesCore" />
    public class UserServicesCore : IUserServicesCore
    {
        #region Private variables
        /// <summary>
        /// The user services repository
        /// </summary>
        private readonly IUserServicesRepository _userServicesRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserServicesCore"/> class.
        /// </summary>
        /// <param name="userServicesRepository">The user services repository.</param>
        public UserServicesCore(IUserServicesRepository userServicesRepository)
        {
            _userServicesRepository = userServicesRepository;
        }
        #endregion

        #region User Services Core
        /// <summary>
        /// Logins the user asynchronous core.
        /// </summary>
        /// <param name="userLoginDto">The user login dto.</param>
        /// <returns></returns>
        public Task<ResponseDto<bool>> LoginUserAsync(UserLoginDto userLoginDto) => _userServicesRepository.LoginUserAsync(userLoginDto);

        /// <summary>
        /// Registers the user asynchronous core.
        /// </summary>
        /// <param name="userRegistrationDto">The user registration dto.</param>
        /// <returns></returns>
        public Task<ResponseDto<UserRegistrationDto>> RegisterUserAsync(UserRegistrationDto userRegistrationDto) => _userServicesRepository.RegisterUserAsync(userRegistrationDto);
        #endregion
    }
}
