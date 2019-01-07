using PayXpertLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDKTest
{
    partial class Program
    {

        private static void TestSubscriptionInstantConversion()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewSaleTransaction();

            var amount = 2500;

            transaction.SetTransactionInformation(amount, "EUR", "50", customerIP);
            transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
            transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");

            // Set the subscription information

            transaction.SetSubscriptionInformation(SubscriptionType.NORMAL, 1000, "P5D", 5, "P1D");

            var response = transaction.Send();

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Sale operation ok. Transaction ID: " + response.transactionID + ", subscription ID: " + response.subscriptionID);
                Console.WriteLine("Performing blacklisting of card number ...");

                var blacklistTransaction = client.NewSubscriptionInstantConversionTransaction(response.subscriptionID);

                var blacklistResponse = blacklistTransaction.Send();

                if (blacklistResponse.IsSuccessfull())
                {
                    Console.WriteLine("Blacklist is ok: " + blacklistResponse.errorMessage);
                }
                else
                {
                    Console.WriteLine("Error blacklisting: " + blacklistResponse.errorMessage);
                }
            }
        }

    }
}
