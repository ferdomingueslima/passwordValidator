using PasswordValidator.Domain.Models;
using PasswordValidator.Domain.Rules;

namespace PasswordValidator.Application.UseCases.Implamentations
{
    public class PasswordValidationUseCase : IPasswordValidationUseCase
    {
        private readonly IEnumerable<IPasswordRule> _rules;
        private readonly ILogger<PasswordValidationUseCase> _logger;

        public PasswordValidationUseCase(IEnumerable<IPasswordRule> rules, ILogger<PasswordValidationUseCase> logger)
        {
            _rules = rules;
            _logger = logger;
        }


        public PasswordResponse isValid(string password)
        {
            _logger.LogInformation("Iniciando validação de senha.");
            var errors = new List<ValidationError>();

            //Possibilidade de incluir métricas. Quais validações falham? Quais falham mais?
            foreach (var rule in _rules)
            {
                if (!rule.Validate(password))
                {
                    errors.Add(new ValidationError
                    {
                        Rule = rule.Rule,
                        Message = rule.Message
                    });
                }
            }

            _logger.LogInformation("Validação de senha concluída. Total de erros: {ErrorCount}", errors.Count);

            return new PasswordResponse
            {
                valid = errors.Count == 0,
                Errors = errors
            };
        }
    }
}
