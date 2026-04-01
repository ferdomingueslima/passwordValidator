using PasswordValidator.Application.DTOs;
using PasswordValidator.Domain.Models;
using System.Linq;

namespace PasswordValidator.Application.Mappers.implementations
{
    public class PasswordResponseMapper : IPasswordResponseMapper
    {
        public PasswordResponseDTO ToDto(PasswordResponse model)
        {
            if (model == null) return null;

            return new PasswordResponseDTO
            {
                valid = model.valid,
                Errors = model.Errors?
                    .Select(e => new ValidationErrorDTO { Rule = e.Rule, Message = e.Message })
                    .ToList() ?? new List<ValidationErrorDTO>()
            };
        }
    }
}
