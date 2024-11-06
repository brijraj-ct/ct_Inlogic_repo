using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Domain.Contracts.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserServicesCore
    {
        #region User Core Contracts
        /// <summary>
        /// Registers the user asynchronous core.
        /// </summary>
        /// <param name="userRegistrationDto">The user registration dto.</param>
        /// <returns></returns>
        Task<ResponseDto<UserRegistrationDto>> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
        /// <summary>
        /// Logins the user asynchronous core.
        /// </summary>
        /// <param name="userLoginDto">The user login dto.</param>
        /// <returns></returns>
        Task<ResponseDto<bool>> LoginUserAsync(UserLoginDto userLoginDto);
        #endregion
    }
}
