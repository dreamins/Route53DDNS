using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53;
using Amazon.Route53.Model;

using Route53DDNS.client;
using Route53DDNS.type;
using Route53DDNS.exception;

namespace Route53DDNS.accessor
{
    // Updates hosted zone's A record with a pre-defined IP
    // note there is no update in route 53 instead it has delete and create in same batch
    // so actually the accessor shall perform two requests - get RR and delete/create it
    class Route53UpdateARecordForHostedZoneAccessor: Accessor<bool>
    {
        private Route53Client client;
        private string hostedZone;
        private string dnsIP;

        public Route53UpdateARecordForHostedZoneAccessor(Route53Client client, string hostedZone, string dnsIP)
        {
            this.client = client;
            this.hostedZone = hostedZone;
            this.dnsIP = dnsIP;
        }

        public override bool get()
        {
            try
            {
                ListResourceRecordSetsResponse response;
                String nextRecordIdentifier = null;
                ResourceRecord recordToUpdate = null;
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
                        // well we still assume that there is only one A record
                        // but at least make minimal defence do not update it
                        // if ip doesn't match

                        recordToUpdate = rrset.ResourceRecords.Find(delegate (ResourceRecord rr) {
                            return !String.IsNullOrWhiteSpace(rr.Value) && rr.Value.Equals(dnsIP);
                        });

                        //update!
                        return true;
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
