using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class WhiteSpaceRuleTests
    {
        private readonly WhiteSpaceRule _rule = new WhiteSpaceRule();

        [Theory]
        [InlineData("", true)]
        [InlineData("abc", true)]
        [InlineData("a b", false)]
        [InlineData(" ", false)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
