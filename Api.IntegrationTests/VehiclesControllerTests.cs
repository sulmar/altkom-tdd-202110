using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using Xunit;

namespace Api.IntegrationTests
{
    // Install-Package Microsoft.AspNetCore.Mvc.Testing

    public class VehiclesControllerTests
    {
        // snippet: tm + 2 x Tab

        private readonly HttpClient client;

        public VehiclesControllerTests()
        {
            var hostBuilder = new HostBuilder()  // add Microsoft.Extensions.Hosting
                  .ConfigureWebHost(webHost =>
                  {
                      webHost.UseTestServer(); // add using Microsoft.AspNetCore.TestHost;
                    webHost.UseStartup<Api.Startup>(); // add using Microsoft.AspNetCore.Hosting;

                });

            var host = hostBuilder.Start();

            // HttpClient client = new HttpClient();

            this.client = host.GetTestClient();

        }

        [Fact]
        public void Get_ExistsId_ShouldReturnsOk()
        {
            // Arrange
            int id = 1;

            string url = $"/api/vehicles/{id}";

            // Act
            var result = client.GetAsync(url).Result;

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }


        [Fact]
        public void Get_NotExists_ShouldReturnsNotFound()
        {
            // Arrange
            int id = int.MaxValue;

            string url = $"/api/vehicles/{id}";

            // Act
            var result = client.GetAsync(url).Result;

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
