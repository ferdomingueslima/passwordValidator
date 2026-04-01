namespace PasswordValidator.Domain.Models
{
    public class ValidationError
    {
        public string Rule { get; set; }
        public string Message { get; set; }
    }
}
