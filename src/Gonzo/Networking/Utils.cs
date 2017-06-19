using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Gonzo.Networking
{
    public static class Utils
    {
        public static IPAddress GetNetworkIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress;
                }
            }

            throw new Exception("Unable to determine IP Address are you Connect to a Network!");
        }

    }
}
