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
}
