using PasswordValidator.Domain.Rules;

namespace PasswordValidator.Application.UseCases.Implamentations
{
    public class PasswordValidation : IPasswordValidation
    {
        private readonly IEnumerable<IPasswordRule> _rules;

        public PasswordValidation(IEnumerable<IPasswordRule> rules) => _rules = rules;


        public bool isValid(string password)
        {
            var failedRules = new List<string>();
            foreach (var rule in _rules)
            {
                if (!rule.Validate(password))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
