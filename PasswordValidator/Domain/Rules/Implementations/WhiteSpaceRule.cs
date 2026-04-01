namespace PasswordValidator.Domain.Rules.Implementations
{
    public class WhiteSpaceRule : IPasswordRule
    {
        public string Rule => "WHITE_SPACE";
        public string Message => "A senha não deve conter espaços em branco";
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
