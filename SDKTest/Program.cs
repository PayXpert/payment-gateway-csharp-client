﻿using PayXpertLibrary;
using System;

namespace SDKTest
{
    class Program
    {
        private static void TestSaleAndRefund()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewSaleTransaction();

            var amount = 1000;

            transaction.SetTransactionInformation(amount, "EUR", "50", "8.8.8.8");
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send();

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Sale operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Querying transaction from server...");

                // Will query transaction from server
                var queryTransactionSale = client.NewQueryTransactionStatus(response.transactionID);
                var transactionInfo = queryTransactionSale.Send();
                Console.WriteLine("Transaction timestamp retrieved from server: " + transactionInfo.transaction.date);
                Console.WriteLine("========================================\n");

                Console.WriteLine("Press any key to try to perform refund");
                Console.ReadKey();

                var refundTransaction = client.NewRefundTransaction(response.transactionID);
                refundTransaction.SetInformationForRefund(amount, null);

                var refundResponse = refundTransaction.Send();

                if (refundResponse.IsSuccessfull())
                {
                    Console.WriteLine("Refund is ok. New transaction ID: " + refundResponse.transactionID);
                } else
                {
                    Console.WriteLine("Error performing refund: " + refundResponse.errorMessage);
                }

                Console.WriteLine("Press any key to try to perform rebill");
                Console.ReadKey();

                var rebillTransaction = client.NewRebillTransaction(response.transactionID);
                rebillTransaction.SetAmount(amount * 2);

                var rebillResponse = rebillTransaction.Send();

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

            var transactions = exportTransactions.Send();

            Console.WriteLine("Total number of retrieved transactions: " + transactions.transactionList.Count.ToString());
        }

        private static void TestAuthAndCapture()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewAuthorizeTransaction();

            var amount = 1250;

            transaction.SetTransactionInformation(amount, "EUR", "50", "8.8.8.8");
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send();

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Authorize operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Performing capture...");

                var captureTransaction = client.NewCaptureTransaction(response.transactionID);
                captureTransaction.SetAmount(amount);

                var captureResponse = captureTransaction.Send();

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

            var amount = 1250;

            transaction.SetTransactionInformation(amount, "EUR", "50", "8.8.8.8");
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            var response = transaction.Send();

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Authorize operation ok. Transaction ID: " + response.transactionID);
                Console.WriteLine("Performing capture...");

                var captureTransaction = client.NewCaptureTransaction(response.transactionID);
                captureTransaction.SetAmount(amount);

                var captureResponse = captureTransaction.Send();

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

        private static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\n=================================\n\n");
                Console.WriteLine("PayXpert C# SDK demo");
                Console.WriteLine("Please choose test to perform:\n");
                Console.WriteLine("1: Sale, refund and rebill");
                Console.WriteLine("2: Export transactions: last month");
                Console.WriteLine("3: Authorize + capture");
                Console.WriteLine("4: Authorize + cancel");
                Console.WriteLine("\nType 0 to exit");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar == '1')
                {
                    TestSaleAndRefund();
                }
                else if (key.KeyChar == '2')
                {
                    TestExportTransactions();
                }
                else if (key.KeyChar == '3')
                {
                    TestAuthAndCapture();
                }
                else if (key.KeyChar == '4')
                {
                    TestAuthAndCancel();
                }
                else if (key.KeyChar == '0')
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }

        static void Main(string[] args)
        {
            DisplayMenu();
        }
    }
}
