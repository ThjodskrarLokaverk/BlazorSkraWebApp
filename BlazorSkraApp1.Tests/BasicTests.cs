using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace RazorPagesProject.Tests.IntegrationTests
{
    public class BasicTests 
        : IClassFixture<WebApplicationFactory<BlazorSkraApp1.Startup>>
    {
        private readonly WebApplicationFactory<BlazorSkraApp1.Startup> _factory;

        public BasicTests(WebApplicationFactory<BlazorSkraApp1.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Index")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }
    }
}