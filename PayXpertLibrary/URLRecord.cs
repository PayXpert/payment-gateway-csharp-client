using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    internal class URLRecord
    {
        public String Url { get; set; }
        public String Method { get; set; }

        public URLRecord(TransactionTypes action, String transactionId)
        {
            if (action == TransactionTypes.AUTHORIZE)
            {
                Url = "transaction/authorize/creditcard";
                Method = "POST";
            }
            else if (action == TransactionTypes.SALE)
            {
                Url = "transaction/sale/creditcard";
                Method = "POST";
            }
            else if (action == TransactionTypes.TODITO_SALE)
            {
                Url = "transaction/sale/todito";
                Method = "POST";
            }
            else if (action == TransactionTypes._3DSCHECK)
            {
                Url = "transaction/3dscheck/creditcard";
                Method = "POST";
            }
            else if (action == TransactionTypes._3DSPARSE)
            {
                Url = "transaction/:transactionID/3dsparse";
                Method = "POST";
            }
            else if (action == TransactionTypes.REFUND)
            {
                Url = "transaction/" + transactionId + "/refund";
                Method = "POST";
            }
            else if (action == TransactionTypes.CREDIT)
            {
                Url = "transaction/:transactionID/credit";
                Method = "POST";
            }
            else if (action == TransactionTypes.CAPTURE)
            {
                Url = "transaction/:transactionID/capture";
                Method = "POST";
            }
            else if (action == TransactionTypes.CANCEL)
            {
                Url = "transaction/:transactionID/cancel";
                Method = "POST";
            }
            else if (action == TransactionTypes.REBILL)
            {
                Url = "transaction/" + transactionId + "/rebill";
                Method = "POST";
            }
            else if (action == TransactionTypes.BLACKLIST_TRANSACTION)
            {
                Url = "transaction/:transactionID/blacklist";
                Method = "POST";
            }
            else if (action == TransactionTypes.BLACKLIST_VALUE)
            {
                Url = "blacklist";
                Method = "POST";
            }
            else if (action == TransactionTypes.CANCEL_SUBSCRIPTION)
            {
                Url = "subscription/:subscriptionID/cancel";
                Method = "POST";
            }
            else if (action == TransactionTypes.INSTANT_CONVERSION)
            {
                Url = "subscription/:subscriptionID/instantconversion";
                Method = "POST";
            }
            else if (action == TransactionTypes.STATUS_SUBSCRIPTION)
            {
                Url = "subscription/:subscriptionID";
                Method = "GET";
            }
            else if (action == TransactionTypes.EXPORT_TRANSACTION_LIST)
            {
                Url = "transactions";

                if (transactionId != null)
                {
                    Url = Url + "/" + transactionId;
                }

                Method = "GET";
            }
            else if (action == TransactionTypes.EXPORT_SUBSCRIPTION)
            {
                Url = "subscriptions";
                Method = "GET";
            }
            else if (action == TransactionTypes.EXPORT_SUBSCRIPTION_OFFER)
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
