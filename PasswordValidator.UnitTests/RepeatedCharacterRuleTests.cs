using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class RepeatedCharacterRuleTests
    {
        private readonly RepeatedCharacterRule _rule = new RepeatedCharacterRule();

        [Theory]
        [InlineData("", true)]
        [InlineData("abc", true)]
        [InlineData("abca", false)]
        [InlineData("aabb", false)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
