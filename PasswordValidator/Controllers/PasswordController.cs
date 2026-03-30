using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Application.Models;
using PasswordValidator.Application.UseCases;

namespace PasswordValidator.Controllers
{
    [ApiController]
    [Route("password-validator")]
    public class PasswordController : ControllerBase
    {
        
        private readonly ILogger<PasswordController> _logger;
        private readonly IPasswordValidation _passwordValidation;

        public PasswordController(ILogger<PasswordController> logger, IPasswordValidation 
            passwordValidation)
        {
            _logger = logger;
            _passwordValidation = passwordValidation;
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromBody] PasswordRequest password)
        {
            var isValid = _passwordValidation.isValid(password.Password);

            return Ok(new { valid = isValid });
        }
    }
}
