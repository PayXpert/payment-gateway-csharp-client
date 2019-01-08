using PayXpertLibrary.Requests;
using PayXpertLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayXpertLibrary
{
    public class Transaction3DSCheck : TransactionBase
    {
        public Transaction3DSCheck(TransactionTypes Type, String OriginatorId, String Password, String BaseURL) : base(Type, OriginatorId, Password, BaseURL, null)
        {
            this.requestObject = new Request3DSCheck();
        }

        public async Task<Response3DSCheckObject> Send()
        {
            return await SendRequestToServer<Response3DSCheckObject>();
        }

        public void SetTransactionInformation(int amount, String currency, String orderId, String customerIP = null)
        {
            var obj = this.requestObject as Request3DSCheck;

            obj.amount = amount;
            obj.currency = currency;
            obj.orderID = orderId;

            obj.customerIP = (customerIP == null) ? "127.0.0.1" : customerIP;
        }

        public void SetCardInformation(String cardNumber, String cardSecurityCode, String cardHolderEmail, String cardExpireMonth, String cardExpireYear)
        {
            var obj = this.requestObject as Request3DSCheck;

            obj.cardNumber = cardNumber;
            obj.cardSecurityCode = cardSecurityCode;
            obj.cardHolderEmail = cardHolderEmail;
            obj.cardExpireMonth = cardExpireMonth;
            obj.cardExpireYear = cardExpireYear;
        }

    }

    public class Transaction3DSParse : TransactionBase
    {
        public Transaction3DSParse(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String transactionId, String PARes) : base(Type, OriginatorId, Password, BaseURL, transactionId)
        {
            var obj = new Request3DSParse();
            obj.transactionID = transactionId;
            obj.PaRes = PARes;
            this.requestObject = obj;
        }

        public async Task<Response3DSParseObject> Send()
        {
            return await SendRequestToServer<Response3DSParseObject>();
        }

    }
}
