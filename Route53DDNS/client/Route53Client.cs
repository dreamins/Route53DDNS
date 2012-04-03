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
    class Route53Client
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Route53Client).FullName);
        private AmazonRoute53Client client;

        public Route53Client(string awsAccessKey, string awsSecretKey)
        {
            logger.Info("Creating Route53 client");
            client = new AmazonRoute53Client(awsAccessKey, awsSecretKey);
        }

        public ListResourceRecordSetsResponse listRecordSets(string hostedZoneId, string startRecordIdentifier)
        {
            logger.Info("Calling ListResourceRecordSets");

            ListResourceRecordSetsRequest request = new ListResourceRecordSetsRequest();
            request.HostedZoneId = hostedZoneId;
            request.MaxItems = "100";
            request.StartRecordIdentifier = startRecordIdentifier;
            return client.ListResourceRecordSets(request); ;
        }
    }
}
