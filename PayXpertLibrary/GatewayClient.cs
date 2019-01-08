using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    public class GatewayClient
    {
        private String url;
        private String originatorId;
        private String password;

        private String proxy = null;

        public GatewayClient(String Url, String OriginatorId, String Password)
        {
            this.url = Url;
            this.originatorId = OriginatorId;
            this.password = Password;
        }

        public GatewayClient(String OriginatorId, String Password)
        {
            this.url = "https://api.payxpert.com";
            this.originatorId = OriginatorId;
            this.password = Password;
        }

        #region Basic transactions

        public SaleTransaction NewSaleTransaction(String transactionId = null)
        {
            return new SaleTransaction(TransactionTypes.SALE, originatorId, password, url, transactionId);
        }

        public SaleTransaction NewAuthorizeTransaction(String transactionId = null)
        {
            return new SaleTransaction(TransactionTypes.AUTHORIZE, originatorId, password, url, transactionId);
        }

        public CaptureRebillCancelTransaction NewCaptureTransaction(String transactionId)
        {
            return new CaptureRebillCancelTransaction(TransactionTypes.CAPTURE, originatorId, password, url, transactionId);
        }

        public CaptureRebillCancelTransaction NewCancelTransaction(String transactionId)
        {
            return new CaptureRebillCancelTransaction(TransactionTypes.CANCEL, originatorId, password, url, transactionId);
        }

        public CaptureRebillCancelTransaction NewCreditFundsTransferTransaction(String transactionId)
        {
            return new CaptureRebillCancelTransaction(TransactionTypes.CREDIT, originatorId, password, url, transactionId);
        }

        public RefundTransaction NewRefundTransaction(String transactionId)
        {
            return new RefundTransaction(TransactionTypes.REFUND, originatorId, password, url, transactionId);
        }

        public CaptureRebillCancelTransaction NewRebillTransaction(String transactionId)
        {
            return new CaptureRebillCancelTransaction(TransactionTypes.REBILL, originatorId, password, url, transactionId);
        }

        public QueryTransactionStatus NewQueryTransactionStatus(String transactionId)
        {
            return new QueryTransactionStatus(TransactionTypes.QUERY_TRANSACTION_STATUS, originatorId, password, url, transactionId);
        }

        public ExportTransactionList NewExportTransactionList(String StartDate, String EndDate, String TransactionOperation)
        {
            return new ExportTransactionList(TransactionTypes.EXPORT_TRANSACTION_LIST, originatorId, password, url, StartDate, EndDate, TransactionOperation);
        }

        public ExportTransactionList NewExportTransactionList(DateTime StartDate, DateTime EndDate, String TransactionOperation)
        {
            var timestampStart = (Int32)(StartDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var timestampEnd = (Int32)(EndDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return NewExportTransactionList(timestampStart.ToString(), timestampEnd.ToString(), TransactionOperation);
        }

        #endregion

        #region Blacklist transactions

        public BlacklistUserTransaction NewBlacklistUserTransaction(String transactionId)
        {
            return new BlacklistUserTransaction(TransactionTypes.BLACKLIST_TRANSACTION, originatorId, password, url, transactionId);
        }

        public BlacklistValueTransaction NewBlacklistValueTransaction()
        {
            return new BlacklistValueTransaction(TransactionTypes.BLACKLIST_VALUE, originatorId, password, url);
        }

        #endregion

        #region Subscription management

        public SubscriptionInstantConversionTransaction NewSubscriptionInstantConversionTransaction(String subscriptionId)
        {
            return new SubscriptionInstantConversionTransaction(TransactionTypes.INSTANT_CONVERSION, originatorId, password, url, subscriptionId);
        }

        public SubscriptionCancelTransaction NewSubscriptionCancelTransaction(String subscriptionId)
        {
            return new SubscriptionCancelTransaction(TransactionTypes.CANCEL_SUBSCRIPTION, originatorId, password, url, subscriptionId);
        }

        public QuerySubscriptionTransaction NewQuerySubscriptionTransaction(String subscriptionId)
        {
            return new QuerySubscriptionTransaction(TransactionTypes.STATUS_SUBSCRIPTION, originatorId, password, url, subscriptionId);
        }

        public ExportSubscriptionsListTransaction NewExportSubscriptionsListTransaction(String StartDate, String EndDate, Boolean allSubscriptions)
        {
            return new ExportSubscriptionsListTransaction(TransactionTypes.EXPORT_SUBSCRIPTION, originatorId, password, url, StartDate, EndDate, allSubscriptions);
        }

        public ExportSubscriptionsListTransaction NewExportSubscriptionsListTransaction(DateTime StartDate, DateTime EndDate, Boolean allSubscriptions)
        {
            var timestampStart = (Int32)(StartDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var timestampEnd = (Int32)(EndDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return NewExportSubscriptionsListTransaction(timestampStart.ToString(), timestampEnd.ToString(), allSubscriptions);
        }

        #endregion


    }
}
