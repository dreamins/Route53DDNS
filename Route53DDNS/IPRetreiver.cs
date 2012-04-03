using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

using Route53DDNS.type;
using Route53DDNS.exception;
using Route53DDNS.accessor;

namespace Route53DDNS
{
    class IPRetreiver
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPRetreiver).FullName);

        public static string getIP(Options opts)
        {
            if (opts.IsExternalIPNeeded)
                return getExternalIP(opts);

            return getInterfaceIP(opts);
        }

        // Extrenal IP in dotted quad format
        private static string getExternalIP(Options opts) 
        {
            foreach (IPProvider provider in opts.IPProviders)
            {
                try
                {
                    string ip = new GetExternalIPAccessor(provider).get();
                    if (ip == null || ip == "")
                    {
                        logger.Warn("Returned IP is either null or empty");
                        continue;
                    }
                    return ip;
                }
                catch (Route53DDNSException e)
                {
                    logger.Error("Error trying to retrieve IP : " + e.ToString());
                }
            }

            throw new ConnectionException("Cannot get external IP from anywhere");
        }

        // Internal IP of one of interfaces for internal dyn dns 
        private static string getInterfaceIP(Options opts)
        {
            return new InterfaceIPAccessor().get();
        }
    }
}
