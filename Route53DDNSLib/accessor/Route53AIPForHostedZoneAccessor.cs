using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53.Model;

using Route53DDNSLib.type;
using Route53DDNSLib.client;
using Route53DDNSLib.exception;

using log4net;

namespace Route53DDNSLib.accessor
{
    // Returns dotted quad A for a single HZ assuming there is only one
    class Route53AIPForHostedZoneAccessor: Accessor<string>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Route53AIPForHostedZoneAccessor).FullName);
        private Route53Client client;
        private string hostedZone;
        private string domainName;

        public Route53AIPForHostedZoneAccessor(Route53Client client, string hostedZone, string domainName)
        {
            this.client = client;
            this.hostedZone = hostedZone;
            this.domainName = domainName;
        }

        public override string get()
        {
            try
            {
                ListResourceRecordSetsResponse response;
                String nextRecordIdentifier = null;
                do
                {
                    response = client.listRecordSets(hostedZone, nextRecordIdentifier);
                    nextRecordIdentifier = response.ListResourceRecordSetsResult.NextRecordIdentifier;

                    foreach (ResourceRecordSet rrset in response.ListResourceRecordSetsResult.ResourceRecordSets)
                    {
                        logger.Debug("Found rrset with name " + rrset.Name);

                        if (rrset.Type != "A")
                        {
                            continue;
                        }

                        logger.Debug("Found rrset with type A!");
                        // We have an A record yay!

                        // if no specific domain name required just update it
                        if (String.IsNullOrEmpty(domainName))
                        {
                            return rrset.ResourceRecords[0].Value;
                        }

                        // if sepcific domain name required, then compare
                        if (String.Equals(domainName.ToLower(), rrset.Name.ToLower())) {
                            logger.Debug("Seems to be the one we need");
                            return rrset.ResourceRecords[0].Value;
                        }
                    }

                } while (response.ListResourceRecordSetsResult.IsTruncated);

                throw new ConfigurationException("Cannot get previous IP from Route53. Make sure you have one A record in your hosted zone!");
            }
            catch (InvalidInputException ex)
            {
                throw new ConfigurationException("Cannot call AWS Route53 " + ex.Message);
            }
        }
    }
}
