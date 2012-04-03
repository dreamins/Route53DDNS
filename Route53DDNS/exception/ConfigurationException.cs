using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNS.exception
{
    class ConfigurationException : Route53DDNSException
    {
        public ConfigurationException(string message) : base(message) { }
    }
}
