namespace PasswordValidator.Domain.Models
{
    public class PasswordResponse
    {
        public bool valid { get; set; }
        public List<ValidationError> Errors { get; set; } = new();
    }
}
