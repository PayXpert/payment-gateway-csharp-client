using PayXpertLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDKTest
{
    partial class Program
    {

        private static void TestSaleAndRefund()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewSaleTransaction();

            var amount = 1000;

            transaction.SetTransactionInformation(amount, "EUR", "50", customerIP);
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send().Result;

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Sale operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Querying transaction from server...");

                // Will query transaction from server
                var queryTransactionSale = client.NewQueryTransactionStatus(response.transactionID);
                var transactionInfo = queryTransactionSale.Send().Result;
                Console.WriteLine("Transaction timestamp retrieved from server: " + transactionInfo.transaction.date);
                Console.WriteLine("========================================\n");

                Console.WriteLine("Press any key to try to perform refund");
                Console.ReadKey();

                var refundTransaction = client.NewRefundTransaction(response.transactionID);
                refundTransaction.SetInformationForRefund(amount, null);

                var refundResponse = refundTransaction.Send().Result;

                if (refundResponse.IsSuccessfull())
                {
                    Console.WriteLine("Refund is ok. New transaction ID: " + refundResponse.transactionID);
                }
                else
                {
                    Console.WriteLine("Error performing refund: " + refundResponse.errorMessage);
                }

                Console.WriteLine("Press any key to try to perform rebill");
                Console.ReadKey();

                var rebillTransaction = client.NewRebillTransaction(response.transactionID);
                rebillTransaction.SetAmount(amount * 2);

                var rebillResponse = rebillTransaction.Send().Result;

                if (rebillResponse.IsSuccessfull())
                {
                    Console.WriteLine("Rebill is ok. New transaction ID: " + rebillResponse.transactionID);
                }
                else
                {
                    Console.WriteLine("Error performing refund: " + rebillResponse.errorMessage);
                }
            }
            else
            {
                Console.WriteLine("Sale operation failed: " + response.errorMessage);
            }
        }

        private static void TestExportTransactions()
        {
            Console.WriteLine("Retrieving list of transactions from server...");

            var currentUnixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var prevUnixTimestamp = currentUnixTimestamp - (60 * 60 * 24 * 30);

            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);

            var exportTransactions = client.NewExportTransactionList(prevUnixTimestamp.ToString(), currentUnixTimestamp.ToString(), null);

            var transactions = exportTransactions.Send().Result;

            Console.WriteLine("Total number of retrieved transactions: " + transactions.transactionList.Count.ToString());
        }

        private static void TestAuthAndCapture()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewAuthorizeTransaction();

            var amount = 1250;

            transaction.SetTransactionInformation(amount, "EUR", "50", customerIP);
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send().Result;

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Authorize operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Performing capture...");

                var captureTransaction = client.NewCaptureTransaction(response.transactionID);
                captureTransaction.SetAmount(amount);

                var captureResponse = captureTransaction.Send().Result;

                if (captureResponse.IsSuccessfull())
                {
                    Console.WriteLine("Capture is ok. New transaction ID: " + captureResponse.transactionID);
                }
                else
                {
                    Console.WriteLine("Error performing capture: " + captureResponse.errorMessage);
                }
            }
        }

        private static void TestAuthAndCancel()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewAuthorizeTransaction();

            var amount = 1420;

            transaction.SetTransactionInformation(amount, "EUR", "50", customerIP);
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send().Result;

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Authorize operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Performing cancel...");

                var cancelTransaction = client.NewCancelTransaction(response.transactionID);
                cancelTransaction.SetAmount(amount);

                var cancelResponse = cancelTransaction.Send().Result;

                if (cancelResponse.IsSuccessfull())
                {
                    Console.WriteLine("Cancel is ok. New transaction ID: " + cancelResponse.transactionID);
                }
                else
                {
                    Console.WriteLine("Error performing cancel: " + cancelResponse.errorMessage);
                }
            }
        }

        private static void TestSaleAndCFT()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewSaleTransaction();

            var amount = 5000;

            transaction.SetTransactionInformation(amount, "EUR", "50", customerIP);
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send().Result;

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Authorize operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Performing transferring of funds ...");

                var creditTransaction = client.NewCreditFundsTransferTransaction(response.transactionID);
                creditTransaction.SetAmount(amount);

                var creditResponse = creditTransaction.Send().Result;

                if (creditResponse.IsSuccessfull())
                {
                    Console.WriteLine("Credit is ok. New transaction ID: " + creditResponse.transactionID);
                }
                else
                {
                    Console.WriteLine("Error performing credit: " + creditResponse.errorMessage);
                }
            }
        }


    }
}
