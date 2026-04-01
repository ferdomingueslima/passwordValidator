using PasswordValidator.Domain.Models;

namespace PasswordValidator.Application.UseCases
{
    public interface IPasswordValidationUseCase
    {
        PasswordResponse isValid(string password);
    }
}
