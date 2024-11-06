using User_Registration_Demo.Domain.DTO;

namespace User_Registration_Demo.Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserServicesRepository
    {
        #region User Repository Contracts
        /// <summary>
        /// Registers the user asynchronous repository.
        /// </summary>
        /// <param name="userRegistrationDto">The user registration dto.</param>
        /// <returns></returns>
        Task<ResponseDto<UserRegistrationDto>> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
        /// <summary>
        /// Logins the user asynchronous repository.
        /// </summary>
        /// <param name="userLoginDto">The user login dto.</param>
        /// <returns></returns>
        Task<ResponseDto<bool>> LoginUserAsync(UserLoginDto userLoginDto);
        #endregion
    }
}
