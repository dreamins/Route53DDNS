using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

using Route53DDNS.exception;

namespace Route53DDNS.type
{
    // various options needed for app to run
    // not a simple type though
    [DataContract]
    class Options
    {
        private const string CONFIG_FILE = "config/config.json";

        [DataMember]
        private string awsAccessKey;
        [DataMember]
        private string awsSecretKey;
        [DataMember]
        private bool externalIPNeeded;
        [DataMember]
        private string hostedZoneId;
        [DataMember]
        private List<IPProvider> ips;

        public bool IsExternalIPNeeded
        {
            get
            {
                return externalIPNeeded;
            }
        }

        public List<IPProvider> IPProviders
        {
            get 
            {
                return ips;
            }
        }

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

        public bool ExternalIPNeeded 
        {
            get
            {
                return externalIPNeeded;
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
                ret.randomize();
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

        private void randomize()
        {
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
        }
    }
}
