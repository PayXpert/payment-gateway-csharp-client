using Newtonsoft.Json;
using PayXpertLibrary.Requests;
using PayXpertLibrary.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PayXpertLibrary
{
    public class SaleTransaction : TransactionBase
    {
        public SaleTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            this.requestObject = new RequestSale();
        }

        public ResponseObject Send()
        {
            return SendRequestToServer();
        }

        public void SetTransactionInformation(int amount, String currency, String orderId, String customerIP = null)
        {
            var obj = this.requestObject as RequestSale;

            obj.amount = amount;
            obj.currency = currency;
            obj.orderID = orderId;

            obj.customerIP = (customerIP == null) ? "127.0.0.1" : customerIP;
        }

        public void SetCardInformation(String cardNumber, String cardSecurityCode, String cardHolderName, String cardExpireMonth, String cardExpireYear)
        {
            var obj = this.requestObject as RequestSale;

            obj.cardNumber = cardNumber;
            obj.cardSecurityCode = cardSecurityCode;
            obj.cardHolderName = cardHolderName;
            obj.cardExpireMonth = cardExpireMonth;
            obj.cardExpireYear = cardExpireYear;
        }

        public void SetShopperInformation(String name, String address, String zipCode, String city, String state, String countryCode, String phone, String email)
        {
            var obj = this.requestObject as RequestSale;

            obj.shopperName = name;
            obj.shopperAddress = address;
            obj.shopperZipcode = zipCode;
            obj.shopperCity = city;
            obj.shopperState = state;
            obj.shopperCountryCode = countryCode;
            obj.shopperPhone = phone;
            obj.shopperEmail = email;
        }

        public void SetOrder(int orderAmount, string productId, String comment = null, String orderDescription = null)
        {
            var obj = this.requestObject as RequestSale;

            obj.orderAmount = orderAmount.ToString();
            obj.productID = productId;
            obj.comment = comment;
            obj.orderDescription = orderDescription;
        }

        public void SetReferralInformation(String transactionID, int amount)
        {
            var obj = this.requestObject as RequestSale;

            obj.amount = amount;
            obj.orderAmount = null;

            SetInUrl("transactionID", transactionID);
        }

        public void SetAffiliate(int affiliateID, String campaignName)
        {
            var obj = this.requestObject as RequestSale;

            obj.affiliateID = affiliateID;
            obj.campaignName = campaignName;
        }

    }

    public class CaptureTransaction : TransactionBase
    {
        public CaptureTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            var request = new RequestCaptureRebill();
            request.transactionID = TransactionId;
            this.requestObject = request;
        }

        public ResponseObject Send()
        {
            return SendRequestToServer();
        }

        public void SetAmount(int amount)
        {
            (requestObject as RequestCaptureRebill).amount = amount;
        }
    }

    public class RebillTransaction : TransactionBase
    {
        public RebillTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            var request = new RequestCaptureRebill();
            request.transactionID = TransactionId; 
            this.requestObject = request;
        }

        public ResponseObject Send()
        {
            return SendRequestToServer();
        }

        public void SetAmountForRebill(int amount)
        {
            (requestObject as RequestCaptureRebill).amount = amount;
        }
    }

    public class RefundTransaction : TransactionBase
    {
        public RefundTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            var request = new RequestRefund();
            request.transactionID = TransactionId;
            this.requestObject = request;
        }

        public ResponseObject Send()
        {
            return SendRequestToServer();
        }

        public void SetInformationForRefund(int Amount, bool? IsSubscription)
        {
            var obj = this.requestObject as RequestRefund;

            obj.amount = Amount;
            obj.cancelSubscription = IsSubscription;
        }

    }

    public class QueryTransactionStatus : TransactionBase
    {
        public QueryTransactionStatus(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {

        }

        public QueryTransactionResponseObject Send()
        {
            return SendRequestToServer<QueryTransactionResponseObject>();
        }

    }

    public class ExportTransactionList : TransactionBase
    {
        private readonly String StartDate;
        private readonly String EndDate;

        private String transactionType = null;
        private String transactionErrorCode = null;


        public ExportTransactionList(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String StartDate, String EndDate, String transactionOperation) : base(Type, OriginatorId, Password, BaseURL, transactionOperation)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public void SetTransactionType(String TransactionType)
        {
            this.transactionType = TransactionType;
        }

        public void SetTransactionErrorCode(String TransactionErrorCode)
        {
            this.transactionErrorCode = TransactionErrorCode;
        }

        public ExportTransactionsReponseObject Send()
        {
            this.getParams = "startDate=" + StartDate + "&endDate=" + EndDate;

            if (this.transactionType != null)
            {
                this.getParams = this.getParams + "&transactionType" + transactionType;
            }

            if (this.transactionErrorCode != null)
            {
                this.getParams = this.getParams + "&transactionErrorCode" + transactionErrorCode;
            }
        
            return SendRequestToServer<ExportTransactionsReponseObject>();
        }

    }
}
