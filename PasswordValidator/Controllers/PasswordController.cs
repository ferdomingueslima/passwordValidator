using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Application.DTOs;
using PasswordValidator.Application.Mappers;
using PasswordValidator.Application.UseCases;

namespace PasswordValidator.Controllers
{
    [ApiController]
    [Route("password")]
    public class PasswordController : ControllerBase
    {

        private readonly ILogger<PasswordController> _logger;
        private readonly IPasswordValidationUseCase _passwordValidation;
        private readonly IPasswordResponseMapper _mapper;

        public PasswordController(ILogger<PasswordController> logger, IPasswordValidationUseCase
            passwordValidation, IPasswordResponseMapper mapper)
        {
            _logger = logger;
            _passwordValidation = passwordValidation;
            _mapper = mapper;
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromBody] PasswordRequestDTO request)
        {
            try
            {
                _logger.LogInformation("Iniciando execução da validação.");
                PasswordResponseDTO responseDTO = _mapper.ToDto(_passwordValidation.isValid(request.Password));

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao validar senha.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno ao processar a validação. Erro: " + ex.Message);
            }

        }
    }
}
