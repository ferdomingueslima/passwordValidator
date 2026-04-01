namespace PasswordValidator.Domain.Rules
{
    public interface IPasswordRule
    {
        string Rule { get; }
        string Message { get; }
        bool Validate(string password);
    }
}
