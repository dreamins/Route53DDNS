using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using log4net;

namespace Route53DDNS
{
    /*
     * Runs periodic updates with Route53
     * 
     */
    class Runner
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Runner).FullName);
        private Object lockObj = new Object();
        private bool running;
        private Options opts;

        public Runner(Options opts)
        {
            this.opts = opts;
            running = false;
        }
        //create a threadpool of one thread and launch a timer with 
        public void start()
        {
            doIt();
        }

        public void stop()
        {

        }

        private void doIt()
        {
            logger.Info("Retrieving IP.");
            string myIP = IPRetreiver.getIP(opts);
            logger.Info("Ip is" + myIP);
        }

        private void updateR53(Options opts)
        {
        }
    }
}
