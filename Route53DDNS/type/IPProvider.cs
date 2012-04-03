using System;
using System.Runtime.Serialization;
using log4net;

namespace Route53DDNS.type
{
    [DataContract]
    class IPProvider
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPProvider).FullName);
        [DataMember]
        private string url;
        [DataMember]
        private string pattern;

        public IPProvider(string url, string pattern)
        {
            this.url = url;
            this.pattern = pattern;
        }

        public string URL
        {
            get
            {
                return url;
            }
        }

        public string Pattern
        {
            get
            {
                return pattern;
            }
        }
    }
}
