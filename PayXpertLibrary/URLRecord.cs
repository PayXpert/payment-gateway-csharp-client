using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    internal class URLRecord
    {
        public String Url { get; set; }
        public String Method { get; set; }

        public URLRecord(String action, String transactionId)
        {
            if (action == "CCAuthorize")
            {
                Url = "transaction/authorize/creditcard";
                Method = "POST";
            }
            else if (action == TransactionTypes.SALE)
            {
                Url = "transaction/sale/creditcard";
                Method = "POST";
            }
            else if (action == "ToditoSale")
            {
                Url = "transaction/sale/todito";
                Method = "POST";
            }
            else if (action == "3DSCheck")
            {
                Url = "transaction/3dscheck/creditcard";
                Method = "POST";
            }
            else if (action == "3DSParse")
            {
                Url = "transaction/:transactionID/3dsparse";
                Method = "POST";
            }
            else if (action == TransactionTypes.REFUND)
            {
                Url = "transaction/" + transactionId + "/refund";
                Method = "POST";
            }
            else if (action == "Credit")
            {
                Url = "transaction/:transactionID/credit";
                Method = "POST";
            }
            else if (action == "Capture")
            {
                Url = "transaction/:transactionID/capture";
                Method = "POST";
            }
            else if (action == "Cancel")
            {
                Url = "transaction/:transactionID/cancel";
                Method = "POST";
            }
            else if (action == TransactionTypes.REBILL)
            {
                Url = "transaction/" + transactionId + "/rebill";
                Method = "POST";
            }
            else if (action == "BlacklistTransaction")
            {
                Url = "transaction/:transactionID/blacklist";
                Method = "POST";
            }
            else if (action == "BlacklistValue")
            {
                Url = "blacklist";
                Method = "POST";
            }
            else if (action == "CancelSubscription")
            {
                Url = "subscription/:subscriptionID/cancel";
                Method = "POST";
            }
            else if (action == "InstantConversion")
            {
                Url = "subscription/:subscriptionID/instantconversion";
                Method = "POST";
            }
            else if (action == "StatusTransaction")
            {
                Url = "transaction/:transactionID";
                Method = "GET";
            }
            else if (action == "StatusSubscription")
            {
                Url = "subscription/:subscriptionID";
                Method = "GET";
            }
            else if (action == "ExportTransaction")
            {
                Url = "transactions/:transactionOperation";
                Method = "GET";
            }
            else if (action == "ExportSubscription")
            {
                Url = "subscriptions";
                Method = "GET";
            }
            else if (action == "ExportSubscriptionOffer")
            {
                Url = "subscription/offer/:offerID";
                Method = "GET";
            }
            else if (action == TransactionTypes.QUERY_TRANSACTION_STATUS)
            {
                Url = "transaction/" + transactionId;
                Method = "GET";
            }

        }

        public void setInURL(String name, String value)
        {
            String paramToReplace = ":" + name;
            this.Url = this.Url.Replace(paramToReplace, value);
        }
    }
}
