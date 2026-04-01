namespace PasswordValidator.Domain.Rules.Implementations
{
    public class SpecialCharacterRule : IPasswordRule
    {
        public string Rule => "SPECIAL_CHARACTER";
        public string Message => "A senha deve ter ao menos um caracter especial";

        private readonly string _specials = "!@#$%^&*()-+";
        public bool Validate(string password)
        {
            //return password.Any(ch => !char.IsLetterOrDigit(ch));
            foreach (char c in password)
            {
                foreach (char special in _specials)
                {
                    if (c == special)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
