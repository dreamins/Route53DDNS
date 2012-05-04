using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Route53.Model;

using Route53DDNSLib.type;

// In theory this better be implementing an interface
namespace Route53DDNSLib.client
{
    interface Route53Client
    {
        // Calls Route53 list for given hostedzone id and record identifier
        ListResourceRecordSetsResponse listRecordSets(string hostedZoneId, string startRecordIdentifier);

        // Replaces given rrset with supplied one for hosted zone
        ChangeResourceRecordSetsResponse updateRRSet(string hostedZoneId, ResourceRecordSet oldRRset, ResourceRecordSet newRRset);
    }
}
