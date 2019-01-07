using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Responses
{
    public class Transaction
    {
        public string transactionID { get; set; }
        public string orderID { get; set; }

        public Int32? referralID { get; set; }
        public Int32? subscriptionID { get; set; }

        public string status { get; set; }
        public string errorCode { get; set; }

        public string operation { get; set; }

        public string paymentType { get; set; }

        public PaymentMeanInfo paymentMeanInfo { get; set; }

        public string date { get; set; }

        public string shopperName { get; set; }
        public string shopperEmail { get; set; }
        public string customerIP { get; set; }

        public Int32? amount { get; set; }
        public string currency { get; set; }

        public string orderDescription { get; set; }
    }
}
