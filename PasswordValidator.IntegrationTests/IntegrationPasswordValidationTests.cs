using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PasswordValidator.Application.DTOs;
using System.Net.Http.Json;

namespace PasswordValidator.IntegrationTests
{
    public class IntegrationPasswordValidationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationPasswordValidationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
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
        public async Task Validate_PasswordScenarios_ReturnsExpected(string password, bool expected)
        {
            var client = _factory.CreateClient();

            var request = new PasswordRequestDTO { Password = password };

            var response = await client.PostAsJsonAsync("/password/validate", request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<ValidationResponse>();

            Assert.True(body is not null);
            Assert.Equal(expected, body.valid);
        }

        private class ValidationResponse
        {
            public bool valid { get; set; }
        }
    }
}
