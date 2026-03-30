namespace PasswordValidator.Domain.Rules.Implementations
{
    public class UppercaseRule : IPasswordRule
    {
        public bool Validate(string password)
        {
            //return password.Any(char.IsUpper);
            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
