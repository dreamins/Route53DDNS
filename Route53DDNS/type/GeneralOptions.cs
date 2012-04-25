using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using log4net;


using Route53DDNS.exception;

namespace Route53DDNS.type
{
    // various options needed for app to run
    // not a simple type though
    [DataContract]
    class GeneralOptions : JSONConfig<GeneralOptions>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GeneralOptions).FullName);
        private const string CONFIG_FILE = "config/config.json";

        [DataMember]
        private bool externalIPNeeded;
        [DataMember]
        private List<IPProvider> ips;

        public List<IPProvider> IPProviders
        {
            get 
            {
                return ips;
            }
        }

        public bool ExternalIPNeeded 
        {
            get
            {
                return externalIPNeeded;
            }
        }


        public void write()
        {
            logger.Info("Writing general options from " + CONFIG_FILE);
            base.write(CONFIG_FILE);
        }

        public static GeneralOptions load()
        {
            logger.Info("Loading general options from " + CONFIG_FILE);
            return JSONConfig<GeneralOptions>.load(CONFIG_FILE).withRandomized();
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
