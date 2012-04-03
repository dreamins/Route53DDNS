using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNS.exception
{
    class ConnectionException : Route53DDNSException
    {
        public ConnectionException(string message) : base(message) { }
    }
}
