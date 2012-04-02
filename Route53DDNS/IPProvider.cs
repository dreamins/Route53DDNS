using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using log4net;

namespace Route53DDNS
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

        public string get()
        {
            logger.Info("Requesting ip from " + url);
            string result = doHttpRequest(url);
            logger.Info("got result " + result);
            Match match = Regex.Match(result, pattern);
            logger.Info("Parsed regex " + match.ToString());
            return match.ToString();
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
