using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53;
using Amazon.Route53.Model;

using log4net;

using Route53DDNSLib.type;

namespace Route53DDNSLib.client
{
    // Shall be recreated on each timed run
    class DefaultRoute53Client : Route53Client
    {
        private sealed class Action
        {

            private readonly String value;

            public static readonly Action CREATE = new Action("CREATE");
            public static readonly Action DELETE = new Action("DELETE");

            private Action(String value)
            {
                this.value = value;
            }
            public override String ToString()
            {
                return value;
            }

        }

        private static readonly ILog logger = LogManager.GetLogger(typeof(Route53Client).FullName);
        private AmazonRoute53Client client;

        public DefaultRoute53Client(string awsAccessKey, string awsSecretKey, string region)
        {
            logger.Info("Creating Route53 client");
            client = new AmazonRoute53Client(awsAccessKey, awsSecretKey, Amazon.RegionEndpoint.GetBySystemName(region));
        }

        public ListResourceRecordSetsResponse listRecordSets(string hostedZoneId, 
            string startRecordIdentifier, string startRecordName, string startRecordType)
        {
            logger.Info("Calling ListResourceRecordSets");
            ListResourceRecordSetsRequest request = new ListResourceRecordSetsRequest() {
                HostedZoneId = hostedZoneId,
                StartRecordIdentifier = startRecordIdentifier,
                StartRecordName = startRecordName,
                StartRecordType = startRecordType
            };
            return client.ListResourceRecordSets(request);
        }


        public ChangeResourceRecordSetsResponse updateRRSet(
            string hostedZoneId, ResourceRecordSet oldRRset, ResourceRecordSet newRRset)
        {
            logger.Info("Calling ChangeResourceRecordSets");
            Change delete = new Change()
            {
                Action = Action.DELETE.ToString(),
                ResourceRecordSet = oldRRset
            };
            Change create = new Change() {
                Action = Action.CREATE.ToString(),
                ResourceRecordSet = newRRset
            };
            List<Change> changes = new List<Change>() { delete, create };

            ChangeBatch batch = new ChangeBatch() { Changes = changes };

            return client.ChangeResourceRecordSets(new ChangeResourceRecordSetsRequest(){
                HostedZoneId = hostedZoneId,
                ChangeBatch = batch
            });
        }
    }
}
