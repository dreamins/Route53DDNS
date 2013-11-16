using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53;
using Amazon.Route53.Model;

using Route53DDNSLib.client;
using Route53DDNSLib.type;
using Route53DDNSLib.exception;

using log4net;

namespace Route53DDNSLib.accessor
{
    // Updates hosted zone's A record with a pre-defined IP
    // note there is no update in route 53 instead it has delete and create in same batch
    // so actually the accessor shall perform two requests - get RR and delete/create it
    class Route53UpdateARecordForHostedZoneAccessor: Accessor<bool>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Route53UpdateARecordForHostedZoneAccessor).FullName);
        private Route53Client client;
        private string hostedZone;
        private string oldIP;
        private string myIP;
        private string domainName;

        public Route53UpdateARecordForHostedZoneAccessor(Route53Client client, string hostedZone, string oldIP, string myIP, string domainName)
        {
            this.client = client;
            this.hostedZone = hostedZone;
            this.oldIP = oldIP;
            this.myIP = myIP;
            this.domainName = domainName;
        }

        public override bool get()
        {
            try
            {
                ListResourceRecordSetsResponse response;
                String nextRecordIdentifier = "";
                String nextRecordName = "";
                String nextRecordType = "";
                ResourceRecord recordToUpdate = null;
                do
                {
                    response = client.listRecordSets(hostedZone, 
                    nextRecordIdentifier, nextRecordName, nextRecordType);
                    nextRecordIdentifier = response.NextRecordIdentifier;
                    nextRecordName = response.NextRecordName;
                    nextRecordType = response.NextRecordType;

                    foreach (ResourceRecordSet RRSet in response.ResourceRecordSets)
                    {
                        if (RRSet.Type == "A")
                        {
                            if( String.IsNullOrEmpty(domainName) || 
                                (!String.IsNullOrEmpty(domainName) && String.Equals(domainName.ToLower(), RRSet.Name.ToLower()))
                              )
                            {
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
                        }

                    }

                } while (response.IsTruncated);

                throw new ConfigurationException("Cannot get previous IP from Route53. Make sure you have one A record in your hosted zone!");
            }
            catch (InvalidInputException ex)
            {
                throw new ConnectionException("Cannot call AWS Route53 " + ex.Message);
            }
        }

        private ResourceRecordSet cloneRRSetWithNewValue(ResourceRecordSet RRSet, string myIP)
        {
            ResourceRecordSet ret = new ResourceRecordSet() {
                AliasTarget = RRSet.AliasTarget,
                Name = RRSet.Name,
                SetIdentifier = RRSet.SetIdentifier,
                TTL = RRSet.TTL,
                Type = RRSet.Type
            };
            ResourceRecord rr = new ResourceRecord() {
                Value = myIP
            };
            ret.ResourceRecords = new List<ResourceRecord>() {rr};

            // Route53 doesn't accept zero weights, and if you set it to zero you'll get an error!
            if (RRSet.Weight != 0) {
                ret.Weight = RRSet.Weight;
            }
            return ret;
        }
    }
}
