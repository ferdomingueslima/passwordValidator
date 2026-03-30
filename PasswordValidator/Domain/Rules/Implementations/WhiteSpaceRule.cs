namespace PasswordValidator.Domain.Rules.Implementations
{
    public class WhiteSpaceRule : IPasswordRule
    {
        public bool Validate(string password)
        {
            //return !password.Any(char.IsWhiteSpace);
            foreach (char c in password)
            {
                if (c == ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
