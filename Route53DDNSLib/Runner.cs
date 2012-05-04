using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using log4net;

using Route53DDNSLib.type;
using Route53DDNSLib.client;
using Route53DDNSLib.accessor;
using Route53DDNSLib.exception;

namespace Route53DDNSLib
{
    /*
     * Runs periodic updates with Route53
     */
    public class Runner
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Runner).FullName);

        private Options opts;
        private Timer timer;
        private bool running;

        public void start()
        {
            stop();

            logger.Info("Runner starting");
            try
            {
                opts = Options.loadFromConfig();
                long initialDelaySec = 0;
                if (opts.GeneralOptions.HasInitialDelay)
                {
                    // calculate start delay from somewhat random, but stable for given client source
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(opts.AWSOptions.AWSAccessKey);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    initialDelaySec = hashBytes[0] % opts.GeneralOptions.TimerPeriodSec;
                    logger.Info("Sleeping for initial delay of " + initialDelaySec + " seconds ");
                }
                else
                {
                    logger.Warn("Initial delay is disabled. This is not recommended!");
                }

                long periodSec = opts.GeneralOptions.TimerPeriodSec < 30 ? 30 : opts.GeneralOptions.TimerPeriodSec;
                periodSec *= 1000;
                timer = new Timer(this.doIt, null, initialDelaySec * 1000, opts.GeneralOptions.TimerPeriodSec * 1000);
                running = true;
            }
            catch (Route53DDNSException ex)
            {
                logger.Error("Caught an exception, cannot start runner", ex);
            }
        }

        public void stop()
        {
            // Stops the timer.. Kind of
            if (timer != null)
            {
                timer.Dispose();
            }
            running = false;
        }

        public bool Running
        {
            get
            {
                return running;
            }
        }

        #region Private functions 
        private void doIt(object state)
        {
            try 
            {
                logger.Info("Woke up!");
                Options localOptions = opts.Clone();
                
                string myIP = new IPAccessor(localOptions).get().Trim();
                logger.Info("Got IP [" + myIP + "]");

                logger.Info("Retrieving IP from Route53");
                Route53Client client = new DefaultRoute53Client(localOptions.AWSOptions.AWSAccessKey, localOptions.AWSOptions.AWSSecretKey);
                Route53AIPForHostedZoneAccessor accessor = new Route53AIPForHostedZoneAccessor(client, localOptions.AWSOptions.HostedZoneId);
                string oldIP = accessor.get().Trim();

                logger.Info("Route53 is pointing to " + oldIP);

                if (oldIP != null && String.Equals(oldIP, myIP))
                {
                    logger.Info("Nothing changed. Bye monster.");
                    return;
                }

                logger.Info("Updating record at Route53 ");
                new Route53UpdateARecordForHostedZoneAccessor(client, localOptions.AWSOptions.HostedZoneId, oldIP, myIP).get();
            } catch (exception.Route53DDNSException ex ) {
                logger.Error("Got an exception haven't done anything perhaps." + ex);
            } catch (Exception ex) {
                logger.Error("Something very bad happened! Bailing out!", ex);
                //die
                throw ex;
            }
        }
        #endregion
    }
}
