using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class LowercaseRuleTests
    {
        private readonly LowercaseRule _rule = new LowercaseRule();

        [Theory]
        [InlineData("", false)]
        [InlineData("ABC", false)]
        [InlineData("aBC", true)]
        [InlineData("abc", true)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
