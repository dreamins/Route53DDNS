using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53;
using Amazon.Route53.Model;

using log4net;

using Route53DDNS.type;

namespace Route53DDNS.client
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

        public DefaultRoute53Client(string awsAccessKey, string awsSecretKey)
        {
            logger.Info("Creating Route53 client");
            client = new AmazonRoute53Client(awsAccessKey, awsSecretKey);
        }

        public ListResourceRecordSetsResponse listRecordSets(string hostedZoneId, string startRecordIdentifier)
        {
            logger.Info("Calling ListResourceRecordSets");
            return client.ListResourceRecordSets(new ListResourceRecordSetsRequest()
                                                    .WithHostedZoneId(hostedZoneId)
                                                    .WithStartRecordIdentifier(startRecordIdentifier));
        }


        public ChangeResourceRecordSetsResponse updateRRSet(string hostedZoneId, ResourceRecordSet oldRRset, ResourceRecordSet newRRset)
        {
            logger.Info("Calling ChangeResourceRecordSets");
            List<Change> changes = new List<Change>() {
                new Change().WithAction(Action.DELETE.ToString()).WithResourceRecordSet(oldRRset),
                new Change().WithAction(Action.CREATE.ToString()).WithResourceRecordSet(newRRset)
            };

            ChangeBatch batch = new ChangeBatch().WithChanges(changes.ToArray());
            return client.ChangeResourceRecordSets(new ChangeResourceRecordSetsRequest()
                                                        .WithHostedZoneId(hostedZoneId)
                                                        .WithChangeBatch(batch));
        }
    }
}
