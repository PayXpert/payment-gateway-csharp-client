using PayXpertLibrary;
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
                rebillTransaction.SetAmountForRebill(amount * 2);

                var rebillResponse = rebillTransaction.Send();

                if (rebillResponse.IsSuccessfull())
                {
                    Console.WriteLine("Rebill is ok. New transaction ID: " + rebillResponse.transactionID);
                }
                else
                {
                    Console.WriteLine("Error performing refund: " + refundResponse.errorMessage);
                }
            }
            else
            {
                Console.WriteLine("Sale operation failed: " + response.errorMessage);
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
                Console.WriteLine("\nType 0 to exit");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar == '1')
                {
                    TestSaleAndRefund();
                }
                else if (key.KeyChar == '0')
                {
                    return;
                } else
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
