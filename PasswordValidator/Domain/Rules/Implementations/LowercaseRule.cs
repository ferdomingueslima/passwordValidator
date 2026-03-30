namespace PasswordValidator.Domain.Rules.Implementations
{
    public class LowercaseRule : IPasswordRule
    {
        public bool Validate(string password)
        {
            //return password.Any(char.IsLower);
            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
