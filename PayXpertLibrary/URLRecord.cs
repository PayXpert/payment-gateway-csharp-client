using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    internal class URLRecord
    {
        public String Url { get; set; }
        public String Method { get; set; }

        public URLRecord(TransactionTypes action, String objectId)
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
                Url = "transaction/" + objectId + "/3dsparse";
                Method = "POST";
            }
            else if (action == TransactionTypes.REFUND)
            {
                Url = "transaction/" + objectId + "/refund";
                Method = "POST";
            }
            else if (action == TransactionTypes.CREDIT)
            {
                Url = "transaction/" + objectId + "/credit";
                Method = "POST";
            }
            else if (action == TransactionTypes.CAPTURE)
            {
                Url = "transaction/" + objectId + "/capture";
                Method = "POST";
            }
            else if (action == TransactionTypes.CANCEL)
            {
                Url = "transaction/" + objectId + "/cancel";
                Method = "POST";
            }
            else if (action == TransactionTypes.REBILL)
            {
                Url = "transaction/" + objectId + "/rebill";
                Method = "POST";
            }
            else if (action == TransactionTypes.BLACKLIST_TRANSACTION)
            {
                Url = "transaction/" + objectId + "/blacklist";
                Method = "POST";
            }
            else if (action == TransactionTypes.BLACKLIST_VALUE)
            {
                Url = "blacklist";
                Method = "POST";
            }
            else if (action == TransactionTypes.CANCEL_SUBSCRIPTION)
            {
                Url = "subscription/" + objectId + "/cancel";
                Method = "POST";
            }
            else if (action == TransactionTypes.INSTANT_CONVERSION)
            {
                Url = "subscription/" + objectId + "/instantconversion";
                Method = "POST";
            }
            else if (action == TransactionTypes.STATUS_SUBSCRIPTION)
            {
                Url = "subscription/" + objectId;
                Method = "GET";
            }
            else if (action == TransactionTypes.EXPORT_TRANSACTION_LIST)
            {
                Url = "transactions";

                if (objectId != null)
                {
                    Url = Url + "/" + objectId;
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
                Url = "subscription/offer/" + objectId;
                Method = "GET";
            }
            else if (action == TransactionTypes.QUERY_TRANSACTION_STATUS)
            {
                Url = "transaction/" + objectId;
                Method = "GET";
            }

        }

        public void SetInURL(String name, String value)
        {
            String paramToReplace = ":" + name;
            this.Url = this.Url.Replace(paramToReplace, value);
        }
    }
}
