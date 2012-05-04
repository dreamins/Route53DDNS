using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Route53DDNSLib.exception
{
    public abstract class Route53DDNSException: Exception
    {
        public Route53DDNSException(string message) : base(message){}
    }
}
