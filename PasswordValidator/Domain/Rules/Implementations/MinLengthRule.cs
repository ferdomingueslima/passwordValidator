namespace PasswordValidator.Domain.Rules.Implementations
{
    public class MinLengthRule: IPasswordRule
    {
        public bool Validate(string password)
        {
            return password.Length >= 9;
        }
    }
}
