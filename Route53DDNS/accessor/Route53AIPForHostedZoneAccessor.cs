using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53.Model;

using Route53DDNS.type;
using Route53DDNS.client;
using Route53DDNS.exception;

namespace Route53DDNS.accessor
{
    // Returns dotted quad A for a single HZ assuming there is only one
    class Route53AIPForHostedZoneAccessor: Accessor<string>
    {
        private Route53Client client;
        private string hostedZone;

        public Route53AIPForHostedZoneAccessor(Route53Client client, string hostedZone)
        {
            this.client = client;
            this.hostedZone = hostedZone;
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
                        if (rrset.Type != "A")
                        {
                            continue;
                        }

                        // We have an A record yay!
                        return rrset.ResourceRecords[0].Value;
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
