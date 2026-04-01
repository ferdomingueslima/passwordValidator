namespace PasswordValidator.Domain.Rules.Implementations
{
    public class LowercaseRule : IPasswordRule
    {
        public string Rule => "LOWERCASE";
        public string Message => "A senha deve ter ao menos uma letra minúscula";
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
