using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNS
{
    class ConnectionException : Exception
    {
        public ConnectionException(string message) : base(message) { }
    }
}
