using System;
using System.Data.SqlClient;
using Xunit;

namespace Api.IntegrationTests
{
    public class SqlServerTests
    {
        [Fact]
        public void Select_WhenCalled_ShouldReturnsValue()
        {
             // Arrange
            var container = new Ductus.FluentDocker.Builders.Builder()
            .UseContainer()
            .WithHostName("localhost")
            .WithEnvironment("ACCEPT_EULA=Y", "SA_PASSWORD=<YourStrong@Passw0rd>")
            .UseImage("mcr.microsoft.com/mssql/server:2019-latest")
            .ExposePort(1433, 1433)
            .WaitForPort("1433/tcp", TimeSpan.FromSeconds(30))
            .Build()
            .Start();

            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=<YourStrong@Passw0rd>;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT 1";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();            

            container.Dispose();
        }
    }
}
