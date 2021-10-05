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

    public class RCar : Target
    {
        public TargetStates State { get; private set; }

        public void Push()
        {
            TcpClient client = new TcpClient();
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
