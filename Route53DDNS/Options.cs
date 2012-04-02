using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

// various options needed for app to run
namespace Route53DDNS
{
    [DataContract]
    class Options
    {
        private const string CONFIG_FILE = "config/config.json";

        [DataMember]
        internal string awsAccessKey;
        [DataMember]
        internal string awsSecretKey;
        [DataMember]
        internal bool externalIPNeeded;
        [DataMember]
        internal List<IPProvider> ips;

        private Options(string awsAccessKey, string awsSecretKey, List<IPProvider> ips)
        {
            this.awsAccessKey = awsAccessKey;
            this.awsSecretKey = awsSecretKey;
            externalIPNeeded = true; //for now
            
            // shuffle IP providers with Knuth-Fisher algo
            Random rand=new Random();
            this.ips = new List<IPProvider>(ips);

            for (int pos = this.ips.Count - 1; pos > 0; pos--)
            {
                int randPos = rand.Next(pos + 1);
                IPProvider tmp = this.ips[pos]; 
                this.ips[pos] = this.ips[randPos];
                this.ips[randPos] = tmp;
            }

        }

        // Factory method to read from config
        public static Options loadFromConfig()
        {
            Options ret = null;
            FileStream stream = null;
            try
            {
                stream = new FileStream(CONFIG_FILE, FileMode.Open);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Options));
                ret = (Options)serializer.ReadObject(stream);

            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            if (ret == null)
            {
                throw new ConfigurationException("Cannot read configuration!");
            }

            return ret;
        }

        public bool isExternalIPNeeded
        {
            get
            {
                return externalIPNeeded;
            }
        }

        public List<IPProvider> ipProviders
        {
            get 
            {
                return ips;
            }
        }

        // Serializes the object into json configuration
        public void writeToConfig()
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(CONFIG_FILE, FileMode.OpenOrCreate);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Options));
                serializer.WriteObject(stream, this);

            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
