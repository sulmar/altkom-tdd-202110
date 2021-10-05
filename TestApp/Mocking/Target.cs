using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public abstract class Target
    {

    }

    public interface ITcpClient
    {
        void Connect(string hostname, int port);
        bool Connected { get; }
    }

    public class StandardTcpClient : ITcpClient
    {
        private TcpClient client;

        public StandardTcpClient()
        {
            client = new TcpClient();
        }

        public bool Connected => client.Connected;

        public void Connect(string hostname, int port)
        {
            client.Connect(hostname, port);
        }
    }

    public class RCar : Target
    {
        public TargetStates State { get; private set; }

        private ITcpClient client;

        public RCar(ITcpClient client)
        {
            this.client = client;
        }

        public void Push()
        {
            client.Connect("127.0.0.1", 9000);

            if (client.Connected)
            {
                if (State == TargetStates.Disabled)
                {
                    State = TargetStates.Enabled;
                }
                else
                {
                    State = TargetStates.Disabled;
                }
            }
        }

    }

    public enum TargetStates
    {
        Enabled,
        Disabled
    }

    
}
