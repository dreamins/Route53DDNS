using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNS
{
    class ConfigurationException: Exception
    {
        public ConfigurationException(string message) : base(message) { }
    }
}
