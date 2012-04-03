using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

using Route53DDNS.type;

namespace Route53DDNS.accessor
{
    class GetExternalIPAccessor: Accessor<String>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GetExternalIPAccessor).FullName);
        IPProvider provider;

        public GetExternalIPAccessor(IPProvider provider)
        {
            this.provider = provider;
        }

        public override string get() 
        {
            try
            {
                logger.Info("Requesting ip from " + provider.URL);
                string result = doHttpRequest(provider.URL);
                logger.Info("got result " + result);
                Match match = Regex.Match(result, provider.Pattern);
                logger.Info("Parsed regex " + match.ToString());
                return match.ToString();
            }
            catch (Exception e)
            {
                throw new exception.ConnectionException("Cannot get external ip. " + e.Message); 
            }
        }

        private static string doHttpRequest(string url)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            int count = 0;
            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // continue building the string
                    sb.Append(Encoding.ASCII.GetString(buf, 0, count));
                }
            }
            while (count > 0); // any more data to read?
            return sb.ToString();
        }
    }
}
