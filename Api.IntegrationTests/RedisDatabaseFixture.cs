using Ductus.FluentDocker.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.IntegrationTests
{
    public class RedisDatabaseFixture : IDisposable
    {
        public IDatabase Database { get; private set; }

        private IContainerService container;

        public RedisDatabaseFixture()
        {
            container = new Ductus.FluentDocker.Builders.Builder()
             .UseContainer()
             .WithHostName("localhost")
             .UseImage("redis")
             .ExposePort(6379, 6379)
             .WaitForPort("6379/tcp", TimeSpan.FromSeconds(30))
             .Build()
             .Start();

            IConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");

            Database = connection.GetDatabase();
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
