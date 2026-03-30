namespace PasswordValidator.Application.UseCases
{
    public interface IPasswordValidation
    {
        bool isValid(string password);
    }
}
