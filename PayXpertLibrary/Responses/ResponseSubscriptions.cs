using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Responses
{
    public class ResponseSubscriptionInstantConversion : BaseResponseObject
    {
        public string transactionID { get; set; }
        public Subscription subscription { get; set; }
    }

    public class ResponseSubscriptionCancel : BaseResponseObject
    {
        public Subscription subscription { get; set; }
    }

    public class ResponseSubscriptionQuery : BaseResponseObject
    {
        public Subscription subscription { get; set; }
        public List<Transaction> transactionList { get; set; }
    }

    public class ResponseSubscriptionExportList : BaseResponseObject
    {
        public List<Subscription> subscriptionList { get; set; }
    }

    public class ResponseSubscriptionExportOffers : BaseResponseObject
    {
        public Offer offer { get; set; }
    }

}
