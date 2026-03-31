using PasswordValidator.Domain.Rules.Implementations;
using Xunit;

namespace PasswordValidator.UnitTests
{
    public class UppercaseRuleTests
    {
        private readonly UppercaseRule _rule = new UppercaseRule();

        [Theory]
        [InlineData("", false)]
        [InlineData("abc", false)]
        [InlineData("Abc", true)]
        [InlineData("ABC", true)]
        public void Validate_ReturnsExpected(string password, bool expected)
        {
            var result = _rule.Validate(password);
            Assert.Equal(expected, result);
        }
    }
}
