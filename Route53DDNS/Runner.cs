using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using log4net;

using Route53DDNS.type;
using Route53DDNS.client;
using Route53DDNS.accessor;

namespace Route53DDNS
{
    /*
     * Runs periodic updates with Route53
     */
    class Runner
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Runner).FullName);

        private Options opts;

        public Runner(Options opts)
        {
            this.opts = opts;
        }
        //create a threadpool of one thread and launch a timer with 
        public void start()
        {
            doIt();
            opts.writeToConfig();
        }

        public void stop()
        {

        }

        private void doIt()
        {
            try 
            {
                logger.Info("Retrieving IP.");
                string myIP = IPRetreiver.getIP(opts).Trim();
                logger.Info("Got IP [" + myIP + "]");

                logger.Info("Retrieving IP from Route53");
                Route53Client client = new Route53Client(opts.AWSAccessKey, opts.AWSSecretKey);
                Route53AIPForHostedZoneAccessor accessor = new Route53AIPForHostedZoneAccessor(client, opts.HostedZoneId);
                string oldIP = accessor.get().Trim();

                logger.Info("DNS is pointing to " + oldIP);

                if (oldIP != null && String.Equals(oldIP, myIP))
                {
                    logger.Info("Nothing changed. Bye monster.");
                    return;
                }

                logger.Info("Updating record at Route53 ");
                new Route53UpdateARecordForHostedZoneAccessor(client, opts.HostedZoneId, oldIP).get();
            } catch (exception.Route53DDNSException ex ) {
                logger.Error("Got an exception haven't done anything perhaps." + ex.Message);
            }
        }

        private void updateR53(Options opts)
        {

        }
    }
}
