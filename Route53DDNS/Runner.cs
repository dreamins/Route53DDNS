using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
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
        private Timer timer;

        public Runner()
        {
        }

        //create a threadpool of one thread and launch a timer with 
        public void start()
        {
            opts = Options.loadFromConfig();
            // calculate start delay from somewhat random, but stable for given client source
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(opts.AWSOptions.AWSAccessKey);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            long initialDelaySec = hashBytes[0] % 60;
            logger.Info("Sleeping for initial delay of " + initialDelaySec + " seconds ");
            timer = new Timer(this.doIt, null, initialDelaySec * 1000, opts.GeneralOptions.TimerPeriodSec * 1000);
        }

        public void stop()
        {
            // Stops the timer.. Kind of
            timer.Dispose();
        }

        private void doIt(object state)
        {
            try 
            {
                logger.Info("Woke up!");
                logger.Info("Retrieving IP.");
                string myIP = IPRetreiver.getIP(opts).Trim();
                logger.Info("Got IP [" + myIP + "]");

                logger.Info("Retrieving IP from Route53");
                Route53Client client = new DefaultRoute53Client(opts.AWSOptions.AWSAccessKey, opts.AWSOptions.AWSSecretKey);
                Route53AIPForHostedZoneAccessor accessor = new Route53AIPForHostedZoneAccessor(client, opts.AWSOptions.HostedZoneId);
                string oldIP = accessor.get().Trim();

                logger.Info("Route53 is pointing to " + oldIP);

                if (oldIP != null && String.Equals(oldIP, myIP))
                {
                    logger.Info("Nothing changed. Bye monster.");
                    return;
                }

                logger.Info("Updating record at Route53 ");
                new Route53UpdateARecordForHostedZoneAccessor(client, opts.AWSOptions.HostedZoneId, oldIP, myIP).get();
            } catch (exception.Route53DDNSException ex ) {
                logger.Error("Got an exception haven't done anything perhaps." + ex.Message);
            }
        }

        private void updateR53(Options opts)
        {

        }
    }
}
