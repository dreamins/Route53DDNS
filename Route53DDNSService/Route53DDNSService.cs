using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.IO;
using Route53DDNSLib;
using log4net;

namespace Route53DDNSService
{
    public partial class Route53DDNSService: ServiceBase
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Route53DDNSService).FullName);
        Runner runner;

        public Route53DDNSService()
        {
            logger.Info("Creating service");
            this.ServiceName = "Route53DDNSService";
            this.CanStop = true;
            this.CanPauseAndContinue = false;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger.Info("Starting service");
            if (runner == null)
            {
                runner = new Runner();
            }
            if (!runner.Running)
            {
                runner.start();
            }
        }

        protected override void OnStop()
        {
            logger.Info("Stopping service");
            runner.stop();
            base.OnStop();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            System.ServiceProcess.ServiceBase.Run(new Route53DDNSService());
        }
    }
}
