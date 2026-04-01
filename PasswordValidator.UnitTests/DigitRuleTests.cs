using PasswordValidator.Domain.Rules.Implementations;

namespace PasswordValidator.UnitTests
{
    public class DigitRuleTests
    {
        private readonly DigitRule _rule = new DigitRule();

        [Theory]
        [InlineData("", false)]
        [InlineData("abc", false)]
        [InlineData("a1c", true)]
        [InlineData("123", true)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
