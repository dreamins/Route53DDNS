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
            logger.Info("Retrieving IP.");
            string myIP = IPRetreiver.getIP(opts);
            logger.Info("Ip is" + myIP);

            Route53Client r53Client = new Route53Client(opts.AWSAccessKey, opts.AWSSecretKey);
            Route53AIPForHostedZoneAccessor accessor = new Route53AIPForHostedZoneAccessor(r53Client, opts.HostedZoneId);

            string oldIP = accessor.get();
            logger.Info("Old ip is" + myIP);
        }

        private void updateR53(Options opts)
        {

        }
    }
}
