using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Responses
{
    public class Subscription
    {
        public Int32? subscriptionID { get; set; }
        public String subscriptionType { get; set; }

        public Int32? offerID { get; set; }
        public Int32? transactionID { get; set; }
        public Int32? amount { get; set; }

        public String period { get; set; }

        public Int32? trialAmount { get; set; }
        public String trialPeriod { get; set; }

        public String state { get; set; }

        public String subscriptionStart { get; set; }
        public String periodStart { get; set; }
        public String periodEnd { get; set; }
        public String cancelDate { get; set; }
        public String cancelReason { get; set; }

        public Int32? iterations { get; set; }
        public Int32? iterationsLeft { get; set; }
        public Int32? retries { get; set; }
    }

    public class Offer
    {
        public Int32? offerID { get; set; }
        public Int32? originatorID { get; set; }

        public String name { get; set; }
        public String description { get; set; }
        public String state { get; set; }

        public String subscriptionType { get; set; }
        public String currency { get; set; }

        public Int32? trialAmount { get; set; }
        public String trialPeriod { get; set; }

        public Int32? rebillAmount { get; set; }
        public String rebillPeriod { get; set; }

        public Int32? rebillMaxIteration { get; set; }
        public Int32? discountAmount { get; set; }

        public String discountPeriod { get; set; }
    }
}
