using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using log4net;


namespace Route53DDNS
{
    class IPRetreiver
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPRetreiver).FullName);

        public static string getIP(Options opts)
        {
            if (opts.isExternalIPNeeded)
                return getExternalIP(opts);

            return getInterfaceIP(opts);
        }

        // Extrenal IP in dotted quad format
        private static string getExternalIP(Options opts) 
        {
            foreach (IPProvider provider in opts.ipProviders)
            {
                try
                {
                    string ip = provider.get();
                    if (ip == null || ip == "")
                    {
                        continue;
                    }
                    return ip;
                }
                catch (Exception e)
                {
                    logger.Error("Error trying to retrieve ip : " + e.ToString());
                }
            }

            throw new ConnectionException("Cannot get external IP from anywhere");
        }

        // Internal IP of one of interfaces for internal dyn dns 
        private static string getInterfaceIP(Options opts)
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }

            if (localIP == "")
            {
                throw new ConnectionException("Cannot get internal IP");
            }
            return localIP;
        }
    }
}
