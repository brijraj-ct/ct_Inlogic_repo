namespace User_Registration_Demo.Domain.Helpers
{
    public static class Constants
    {
        #region Regiter Messages
        public const string RegisterSuccessMessage = "User registered successfully.";
        public const string RegisterFailedMessage = "User registration failed.";
        #endregion

        #region Login Messages
        public const string LoginEmailFailedMessage = "Provided email is not valid.";
        public const string LoginPasswordFailedMessage = "Provided password is not valid.";
        public const string LoginSuccessMessage = "Logged in successfully.";
        public const string LoginFailureMessage = "Invalid login.";
        #endregion
    }
}
