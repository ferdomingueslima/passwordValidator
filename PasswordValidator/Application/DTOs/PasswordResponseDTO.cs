namespace PasswordValidator.Application.DTOs
{
    public class PasswordResponseDTO
    {
        public bool valid { get; set; }
        public List<ValidationErrorDTO> Errors { get; set; } = new();
    }
}
