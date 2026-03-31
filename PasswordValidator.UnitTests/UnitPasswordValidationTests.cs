using PasswordValidator.Application.UseCases;
using PasswordValidator.Application.UseCases.Implamentations;
using PasswordValidator.Domain.Rules;
using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class UnitPasswordValidationTests
    {

        private readonly IPasswordValidation _passwordValidation;
        
        public UnitPasswordValidationTests()
        {
            //Arrange
            var rules = new IPasswordRule[]
            {
                new MinLengthRule(),
                new UppercaseRule(),
                new LowercaseRule(),
                new DigitRule(),
                new SpecialCharacterRule(),
                new RepeatedCharacterRule(),
                new WhiteSpaceRule()
            };
            _passwordValidation = new PasswordValidation(rules);
        }

        public static IEnumerable<object[]> PasswordScenarios =>
           new List<object[]>
           {
                new object[] { "", false },
                new object[] { "aa", false },
                new object[] { "ab", false },
                new object[] { "AAAbbbCc", false },
                new object[] { "AbTp9!foo", false },
                new object[] { "AbTp9!foA", false },
                new object[] { "AbTp9 fok", false },
                new object[] { "AbTp9!fok", true }
           };

        [Theory]
        [MemberData(nameof(PasswordScenarios))]
        public void Should_Validate_Password_Correctly(string password, bool expected)
        {
            // Act
            var result = _passwordValidation.isValid(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
