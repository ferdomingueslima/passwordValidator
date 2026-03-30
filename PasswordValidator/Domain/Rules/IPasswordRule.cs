using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Domain.Rules
{
    public interface IPasswordRule
    {
        bool Validate(string password);
    }
}
