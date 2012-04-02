using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// various options needed for app to run
namespace Route53DDNS
{
    class Options
    {
        private string awsAccessKey;
        private string awsSecretKey;
        private bool externalIPNeeded;
        private List<IPProvider> ips;

        public Options(string awsAccessKey, string awsSecretKey, List<IPProvider> ips)
        {
            this.awsAccessKey = awsAccessKey;
            this.awsSecretKey = awsSecretKey;
            externalIPNeeded = true; //for now
            
            // shuffle IP providers with Knuth-Fisher algo
            Random rand=new Random();
            this.ips = new List<IPProvider>(ips);

            for (int pos = this.ips.Count - 1; pos > 0; pos--)
            {
                int randPos = rand.Next(pos + 1);
                IPProvider tmp = this.ips[pos]; 
                this.ips[pos] = this.ips[randPos];
                this.ips[randPos] = tmp;
            }

        }

        // Factory method to read from config
        public static Options loadFromConfig()
        {    
            List<IPProvider> ips = new List<IPProvider>();
            
            ips.Add(new IPProvider("http://whatismyip.org/", "(.)*"));
            ips.Add(new IPProvider("http://strewth.org/ip.php", "([\\d]{1,3}\\.[\\d]{1,3}\\.[\\d]{1,3}\\.[\\d]{1,3})"));
            ips.Add(new IPProvider("http://checkip.amazonaws.com/", "(.)*"));
            
            // Read
            return new Options("", "", ips);
        }

        public bool isExternalIPNeeded
        {
            get
            {
                return externalIPNeeded;
            }
        }

        public List<IPProvider> ipProviders
        {
            get 
            {
                return ips;
            }
        }
    }
}
