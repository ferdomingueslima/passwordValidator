using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class MinLengthRuleTests
    {
        private readonly MinLengthRule _rule = new MinLengthRule();

        [Theory]
        [InlineData("", false)]
        [InlineData("12345678", false)]
        [InlineData("123456789", true)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
