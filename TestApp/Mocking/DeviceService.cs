using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public class DeviceService
    {
        public DeviceStatus GetStatus(int deviceId)
        {
            WebClient client = new WebClient();

            string url = $"http://domain.com/devices/{deviceId}";

            string xml = client.DownloadString(url);

            if (xml == "<status>0</status>")
            {
                return DeviceStatus.Ready;
            }
            else if (xml == "<status>1</status>")
            {
                return DeviceStatus.Cooling;
            }
            else if (xml == "<status>2</status>")
            {
                return DeviceStatus.Heating;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }

    public enum DeviceStatus
    {
        Ready,
        Cooling,
        Heating
    }
}
