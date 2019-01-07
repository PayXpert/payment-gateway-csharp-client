using PayXpertLibrary.Requests;
using PayXpertLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    public class SubscriptionInstantConversionTransaction : TransactionBase
    {
        public SubscriptionInstantConversionTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }

        public ResponseSubscriptionInstantConversion Send()
        {
            return SendRequestToServer<ResponseSubscriptionInstantConversion>();
        }

    }

    public class SubscriptionCancelTransaction : TransactionBase
    {
        public SubscriptionCancelTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {

        }

        public ResponseSubscriptionCancel Send()
        {
            return SendRequestToServer<ResponseSubscriptionCancel>();
        }

        public void SetCancelReason(int reason)
        {
            var obj = new RequestCancelSubscription();
            obj.cancelReason = reason;
            this.requestObject = obj;
        }
    }

    public class QuerySubscriptionTransaction : TransactionBase
    {
        public QuerySubscriptionTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {

        }

        public ResponseSubscriptionQuery Send()
        {
            return SendRequestToServer<ResponseSubscriptionQuery>();
        }

    }


}
