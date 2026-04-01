namespace PasswordValidator.Domain.Rules.Implementations
{
    public class MinLengthRule : IPasswordRule
    {
        public string Rule => "MIN_LENGTH";
        public string Message => "A senha deve ter pelo menos 9 caracteres";
        public bool Validate(string password)
        {
            return password.Length >= 9;
        }
    }
}
