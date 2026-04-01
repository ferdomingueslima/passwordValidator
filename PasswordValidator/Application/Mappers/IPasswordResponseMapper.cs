using PasswordValidator.Application.DTOs;
using PasswordValidator.Domain.Models;

namespace PasswordValidator.Application.Mappers
{
    public interface IPasswordResponseMapper
    {
        PasswordResponseDTO ToDto(PasswordResponse model);
    }
}
