using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Responses
{
    public class BaseResponseObject
    {
        public string errorCode { get; set; }
        public string errorMessage { get; set; }

        public bool IsSuccessfull()
        {
            return errorCode == "000";
        }
    }

    public class ResponseObject : BaseResponseObject
    {
        public string transactionID { get; set; }
    }

    public class SaleResponseObject : ResponseObject
    {
        public string statementDescriptor { get; set; }
        public PaymentMeanInfo paymentMeanInfo { get; set; }

        // Optional AVS fields

        public string AVSResult { get; set; }
        public string FSResult { get; set; }
        public string FSStatus { get; set; }

        // Optional automated subscription fields

        public string subscriptionID { get; set; }
    }

    public class QueryTransactionResponseObject : ResponseObject
    {
        public Transaction transaction { get; set; }
    }

    public class ExportTransactionsReponseObject : BaseResponseObject
    {
        public List<Transaction> transactionList { get; set; }
    }
}
