using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

using Route53DDNS.type;
using Route53DDNS.exception;
using Route53DDNS.accessor;

namespace Route53DDNS.accessor
{
    class IPAccessor : Accessor<string>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPAccessor).FullName);
        private Options opts;

        public IPAccessor(Options opts)
        {
            this.opts = opts;
        }

        public override string get()
        {
            if (opts.GeneralOptions.ExternalIPNeeded)
                return getExternalIP(opts);
            return getInterfaceIP(opts);
        }

        #region Private functions
        // Extrenal IP in dotted quad format
        private static string getExternalIP(Options opts) 
        {
            logger.Info("Retrieving IP");
            foreach (IPProvider provider in opts.GeneralOptions.IPProviders)
            {
                if (provider.Disabled)
                {
                    continue;
                }

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
        #endregion 
    }
}
