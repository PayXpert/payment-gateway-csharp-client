using PayXpertLibrary.Requests;
using PayXpertLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayXpertLibrary
{
    public class SubscriptionInstantConversionTransaction : TransactionBase
    {
        public SubscriptionInstantConversionTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }

        public async Task<ResponseSubscriptionInstantConversion> Send()
        {
            return await SendRequestToServer<ResponseSubscriptionInstantConversion>();
        }

    }

    public class SubscriptionCancelTransaction : TransactionBase
    {
        public SubscriptionCancelTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {

        }

        public async Task<ResponseSubscriptionCancel> Send()
        {
            return await SendRequestToServer<ResponseSubscriptionCancel>();
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

        public async Task<ResponseSubscriptionQuery> Send()
        {
            return await SendRequestToServer<ResponseSubscriptionQuery>();
        }

    }

    public class ExportSubscriptionsListTransaction : TransactionBase
    {
        public ExportSubscriptionsListTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String startDate, String endDate, bool allSubscriptions) : base(Type, OriginatorId, Password, BaseURL, null)
        {
            String allSubscriptionsSym = allSubscriptions ? "1" : "0";
            this.getParams = "startDate=" + startDate + "&endDate=" + endDate + "&allSubscriptions=" + allSubscriptionsSym;
        }

        public async Task<ResponseSubscriptionExportList> Send()
        {
            return await SendRequestToServer<ResponseSubscriptionExportList>();
        }

    }

    public class ExportSubscriptionOfferTransaction : TransactionBase
    {
        public ExportSubscriptionOfferTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String OfferId) : base(Type, OriginatorId, Password, BaseURL, OfferId)
        {

        }

        public async Task<ResponseSubscriptionExportOffer> Send()
        {
            return await SendRequestToServer<ResponseSubscriptionExportOffer>();
        }

    }

}
