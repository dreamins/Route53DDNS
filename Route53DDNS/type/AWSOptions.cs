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
    // various options needed for app to run
    // not a simple type though
    [DataContract]
    class AWSOptions : JSONConfig<AWSOptions>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(AWSOptions).FullName);
        private const string CONFIG_FILE = "config/aws.json";

        [DataMember]
        private string awsAccessKey;
        [DataMember]
        private string awsSecretKey;
        [DataMember]
        private string hostedZoneId;

        public string HostedZoneId
        {
            get
            {
                return hostedZoneId;
            }
        }

        public string AWSAccessKey
        {
            get
            {
                return awsAccessKey;
            }
        }

        public string AWSSecretKey
        {
            get
            {
                return awsSecretKey;
            }
        }

        public void write()
        {
            logger.Info("Writing AWS options to " + CONFIG_FILE);
            base.write(CONFIG_FILE);
        }

        public static AWSOptions load() 
        {
            logger.Info("Loading AWS options from " + CONFIG_FILE);
            return JSONConfig<AWSOptions>.load(CONFIG_FILE);
        }

    }
}
