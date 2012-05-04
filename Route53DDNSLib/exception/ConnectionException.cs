using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNSLib.exception
{
    public class ConnectionException : Route53DDNSException
    {
        public ConnectionException(string message) : base(message) { }
    }
}
