using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public interface IWebClient
    {
        string DownloadString(string url);
    }

    public class StandardWebClient : IWebClient
    {
        private WebClient client = new WebClient();

        public string DownloadString(string url) => client.DownloadString(url);
    }

    public class DeviceService
    {
        private readonly IWebClient client;

        public DeviceService()
            : this(new StandardWebClient())
        {

        }

        public DeviceService(IWebClient client)
        {
            this.client = client;
        }

        public DeviceStatus GetStatus(int deviceId)
        {
            string url = $"http://domain.com/devices/{deviceId}";

            string xml = client.DownloadString(url);

            return Map(xml);
        }

        private static DeviceStatus Map(string xml)
        {
            Regex regex = new Regex(@"^<status>(\d)<\/status>");

            Match match = regex.Match(xml);

            string statusString = match.Groups[1].Value;

            int status = int.Parse(statusString);

            DeviceStatus deviceStatus = (DeviceStatus)status;

            return deviceStatus;
            
        }
    }

    public enum DeviceStatus
    {
        Ready,
        Cooling,
        Heating
    }
}
