using System;
using System.Runtime.Serialization;
using log4net;

namespace Route53DDNSLib.type
{
    [DataContract]
    public class IPProvider
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPProvider).FullName);
        [DataMember]
        private string url;
        [DataMember]
        private string pattern;
        [DataMember]
        private bool enabled;

        public IPProvider(string url, string pattern, bool enabled)
        {
            this.url = url;
            this.pattern = pattern;
            this.enabled = enabled;
        }

        public string URL
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Pattern
        {
            get
            {
                return pattern;
            }

            set
            {
                pattern = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        public bool Disabled
        {
            get
            {
                return !enabled;
            }

            set
            {
                enabled = !value;
            }
        }
    }
}
