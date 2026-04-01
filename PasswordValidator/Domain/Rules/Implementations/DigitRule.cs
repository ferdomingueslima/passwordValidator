namespace PasswordValidator.Domain.Rules.Implementations
{
    public class DigitRule : IPasswordRule
    {

        public string Rule => "DIGIT";
        public string Message => "A senha deve ter ao menos um número";

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
