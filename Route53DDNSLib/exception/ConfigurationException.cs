using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNSLib.exception
{
    public class ConfigurationException : Route53DDNSException
    {
        public ConfigurationException(string message) : base(message) { }
    }
}
