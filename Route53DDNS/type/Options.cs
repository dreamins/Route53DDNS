using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using log4net;

using Route53DDNS.exception;

namespace Route53DDNS.type
{
    // A fascade for options
    class Options
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Options).FullName);
        private GeneralOptions generalOptions;
        private AWSOptions awsOptions;
        private static Object lockObject = new Object();

        private Options(GeneralOptions generalOpts, AWSOptions awsOpts)
        {
            this.generalOptions = generalOpts;
            this.awsOptions = awsOpts;
        }

        public GeneralOptions GeneralOptions
        {
            get
            {
                return generalOptions;
            }
        }

        public AWSOptions AWSOptions
        {
            get
            {
                return awsOptions;
            }
        }

        // Serializes the object into json configuration
        public void writeToConfig()
        {
            lock (lockObject)
            {
                logger.Info("Writing configuration");
                // yeah we might end up with partially written files
                // but shall we care?
                generalOptions.write();
                awsOptions.write();
            }
        }

        // Factory method to read from config
        public static Options loadFromConfig()
        {
            lock (lockObject)
            {
                logger.Info("Loading configuration");
                GeneralOptions generalOpts = GeneralOptions.load();
                AWSOptions awsOpts = AWSOptions.load();
                return new Options(generalOpts, awsOpts);
            }
        }

        public Options Clone()
        {
            lock (lockObject)
            {
                GeneralOptions generalOpts = generalOptions.Clone();
                AWSOptions awsOpts = awsOptions.Clone();
                return new Options(generalOptions, awsOptions);
            }
        }
    }
}
