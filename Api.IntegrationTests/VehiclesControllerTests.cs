using System;
using System.Net.Http;
using Xunit;

namespace Api.IntegrationTests
{
    public class VehiclesControllerTests
    {
        // snippet: tm + 2 x Tab

        [Fact]
        public void Get_ExistsId_ShouldReturnsOk()
        {
            // Arrange
            HttpClient client = new HttpClient();

            int id = 1;

            string url = $"https://localhost:44352/api/vehicles/{id}";

            // Act
            var result = client.GetAsync(url).Result;

            // Assets
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }


        [Fact]
        public void Get_NotExists_ShouldReturnsNotFound()
        {
            // Arrange
            HttpClient client = new HttpClient();

            int id = int.MaxValue;

            string url = $"https://localhost:44352/api/vehicles/{id}";

            // Act
            var result = client.GetAsync(url).Result;

            // Assets
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
