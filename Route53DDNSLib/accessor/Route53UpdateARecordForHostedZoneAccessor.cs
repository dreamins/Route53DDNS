using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53;
using Amazon.Route53.Model;

using Route53DDNSLib.client;
using Route53DDNSLib.type;
using Route53DDNSLib.exception;

namespace Route53DDNSLib.accessor
{
    // Updates hosted zone's A record with a pre-defined IP
    // note there is no update in route 53 instead it has delete and create in same batch
    // so actually the accessor shall perform two requests - get RR and delete/create it
    class Route53UpdateARecordForHostedZoneAccessor: Accessor<bool>
    {
        private Route53Client client;
        private string hostedZone;
        private string oldIP;
        private string myIP;

        public Route53UpdateARecordForHostedZoneAccessor(Route53Client client, string hostedZone, string oldIP, string myIP)
        {
            this.client = client;
            this.hostedZone = hostedZone;
            this.oldIP = oldIP;
            this.myIP = myIP;
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

                    foreach (ResourceRecordSet RRSet in response.ListResourceRecordSetsResult.ResourceRecordSets)
                    {
                        if (RRSet.Type != "A")
                        {
                            continue;
                        }
                        // well we still assume that there is only one A record
                        // but at least make minimal defence do not update it
                        // if ip doesn't match
                        recordToUpdate = RRSet.ResourceRecords.Find(delegate(ResourceRecord rr)
                        {
                            return !String.IsNullOrWhiteSpace(rr.Value) && rr.Value.Equals(oldIP);
                        });

                        
                        //update assemble a delete/add batch
                        client.updateRRSet(this.hostedZone, RRSet,  cloneRRSetWithNewValue(RRSet, myIP));

                        // well we either throw an exception, or request is succesfully done
                        // the point here is that we don't really need to poll for the result from R53
                        // it will either go in sync, or we will retry next time!
                        return true;
                    }

                } while (response.ListResourceRecordSetsResult.IsTruncated);

                throw new ConfigurationException("Cannot get previous IP from Route53. Make sure you have one A record in your hosted zone!");
            }
            catch (InvalidInputException ex)
            {
                throw new ConnectionException("Cannot call AWS Route53 " + ex.Message);
            }
        }

        private ResourceRecordSet cloneRRSetWithNewValue(ResourceRecordSet RRSet, string myIP)
        {
            ResourceRecordSet ret = new ResourceRecordSet()
                .WithAliasTarget(RRSet.AliasTarget)
                .WithName(RRSet.Name)
                .WithSetIdentifier(RRSet.SetIdentifier)
                .WithTTL(RRSet.TTL)
                .WithType(RRSet.Type)
                .WithResourceRecords(new List<ResourceRecord>() {
                    new ResourceRecord().WithValue(myIP)
                });

            // Route53 doesn't accept zero weights, and if you set it to zero you'll get an error!
            return RRSet.Weight != 0 ? ret.WithWeight(RRSet.Weight) : ret;
        }
    }
}
