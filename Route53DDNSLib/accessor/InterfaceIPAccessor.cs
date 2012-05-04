using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using log4net;

using Route53DDNSLib.exception;

namespace Route53DDNSLib.accessor
{
    class InterfaceIPAccessor: Accessor<string>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(InterfaceIPAccessor).FullName);
        public InterfaceIPAccessor() {}

        public override string get()
        {

            logger.Info("Querying for interface IP");
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
