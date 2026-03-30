namespace PasswordValidator.Domain.Rules.Implementations
{
    public class RepeatedCharacterRule : IPasswordRule
    {
        public bool Validate(string password)
        {
            var charSet = new HashSet<char>();

            foreach (char c in password)
            {
                if (!charSet.Add(c))
                    return false;
            }
            return true;
        }
    }
}
