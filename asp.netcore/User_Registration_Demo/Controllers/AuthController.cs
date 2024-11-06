using Microsoft.AspNetCore.Mvc;
using User_Registration_Demo.Domain.Contracts.Core;
using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Private variables
        /// <summary>
        /// The user services core
        /// </summary>
        private readonly IUserServicesCore _userServicesCore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userServicesCore">The user services core.</param>
        public AuthController(IUserServicesCore userServicesCore)
        {
            _userServicesCore = userServicesCore;
        }
        #endregion

        #region APIs
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userRegistrationDto">The user registration dto.</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ResponseDto<UserRegistrationDto>> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            return  await _userServicesCore.RegisterUserAsync(userRegistrationDto);
            
        }

        /// <summary>
        /// Logins the specified user login dto.
        /// </summary>
        /// <param name="userLoginDto">The user login dto.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ResponseDto<bool>> Login(UserLoginDto userLoginDto) => await _userServicesCore.LoginUserAsync(userLoginDto);
        #endregion
    }
}
