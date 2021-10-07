using Ductus.FluentDocker.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests
{

    public class RedisTests
    {

        [Fact]
        public void Ping_WhenCalled_ShouldReturnsPong()
        {
            // Arrange
            var container = new Ductus.FluentDocker.Builders.Builder()
            .UseContainer()
            .WithHostName("localhost")
            .UseImage("redis")
            .ExposePort(6379, 6379)
            .WaitForPort("6379/tcp", TimeSpan.FromSeconds(30))
            .Build()
            .Start();

            IConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");

            var Database = connection.GetDatabase();

            // Act
            var result = Database.Ping();

            // Assert
            Assert.NotEqual(TimeSpan.Zero, result);
        }

        [Fact]
        public void SetAdd_WhenCalled_ShouldReturnsTrue()
        {
            // Arrange
            var container = new Ductus.FluentDocker.Builders.Builder()
            .UseContainer()
            .WithHostName("localhost")
            .UseImage("redis")
            .ExposePort(6379, 6379)
            .WaitForPort("6379/tcp", TimeSpan.FromSeconds(30))
            .Build()
            .Start();

            IConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");

            var Database = connection.GetDatabase();

            // Act
            var result = Database.SetAdd("key1", "a");

            // Assert
            Assert.True(result);
        }

    }


    public class SharedRedisTests : IClassFixture<RedisDatabaseFixture>
    {
        private readonly RedisDatabaseFixture fixture;

        public SharedRedisTests(RedisDatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Ping_WhenCalled_ShouldReturnsPong()
        {
            // Arrange

            // Act
            var result = fixture.Database.Ping();

            // Assert
            Assert.NotEqual(TimeSpan.Zero, result);
        }

        [Fact]
        public void SetAdd_WhenCalled_ShouldReturnsTrue()
        {
            // Act
            var result = fixture.Database.SetAdd("key1", "a");

            // 
            Assert.True(result);
        }
    }
}
