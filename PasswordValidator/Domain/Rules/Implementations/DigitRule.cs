namespace PasswordValidator.Domain.Rules.Implementations
{
    public class DigitRule : IPasswordRule
    {
        public bool Validate(string password)
        {
            //return password.Any(char.IsDigit);
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
