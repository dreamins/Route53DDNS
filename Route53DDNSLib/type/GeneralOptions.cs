using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using log4net;


using Route53DDNSLib.exception;

namespace Route53DDNSLib.type
{
    // various options needed for app to run
    // not a simple type though
    [DataContract]
    public class GeneralOptions : JSONConfig<GeneralOptions>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GeneralOptions).FullName);
        private const string CONFIG_FILE = "config/config.json";

        [DataMember]
        private bool externalIPNeeded;
        
        [DataMember]
        private List<IPProvider> ips;
        
        [DataMember]
        private long timerPeriodSec;

        [DataMember]
        private bool hasInitialDelay;

        [DataMember]
        private bool runOnStart;

        [DataMember]
        private string domainName;

        public List<IPProvider> IPProviders
        {
            get 
            {
                return ips;
            }

            set
            {
                ips = value;
            }
        }

        public bool ExternalIPNeeded 
        {
            get
            {
                return externalIPNeeded;
            }

            set
            {
                externalIPNeeded = value;
            }
        }

        public long TimerPeriodSec
        {
            get
            {
                return timerPeriodSec;
            }

            set
            {
                timerPeriodSec = value;
            }
        }

        public bool HasInitialDelay
        {
            get
            {
                return hasInitialDelay;
            }

            set
            {
                hasInitialDelay = value;
            }
        }

        public bool RunOnStart
        {
            get
            {
                return runOnStart;
            }

            set
            {
                runOnStart = value;
            }
        }

        public string DomainName
        {
            get
            {
                return domainName;
            }

            set
            {
                domainName = value;
            }
        }

        internal void write()
        {
            logger.Info("Writing general options from " + CONFIG_FILE);
            base.write(CONFIG_FILE);
        }

        internal static GeneralOptions load()
        {
            logger.Info("Loading general options from " + CONFIG_FILE);
            return JSONConfig<GeneralOptions>.load(CONFIG_FILE).withRandomized();
        }

        internal GeneralOptions Clone()
        {
            MemoryStream stream = new MemoryStream();
            base.write(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return JSONConfig<GeneralOptions>.load(stream);
        }

        private GeneralOptions withRandomized()
        {
            logger.Info("Randomizing IP sources");
            // shuffle IP providers with Knuth-Fisher algo
            Random rand = new Random();
            this.ips = new List<IPProvider>(ips);

            for (int pos = this.ips.Count - 1; pos > 0; pos--)
            {
                int randPos = rand.Next(pos + 1);
                IPProvider tmp = this.ips[pos];
                this.ips[pos] = this.ips[randPos];
                this.ips[randPos] = tmp;
            }

            return this;
        }
    }
}
