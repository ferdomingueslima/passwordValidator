using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class SpecialCharacterRuleTests
    {
        private readonly SpecialCharacterRule _rule = new SpecialCharacterRule();

        [Theory]
        [InlineData("", false)]
        [InlineData("abc", false)]
        [InlineData("abc!", true)]
        [InlineData("@test", true)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
