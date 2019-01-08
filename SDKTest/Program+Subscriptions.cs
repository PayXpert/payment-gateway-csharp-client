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

            var response = transaction.Send().Result;

            if (response.IsSuccessfull())
            {
                Console.WriteLine("Sale operation ok. Transaction ID: " + response.transactionID + ", subscription ID: " + response.subscriptionID);
                Console.WriteLine("Performing instant subscription conversion ...");

                var instantConversionTransaction = client.NewSubscriptionInstantConversionTransaction(response.subscriptionID);
                var instantConversionResponse = instantConversionTransaction.Send().Result;

                if (instantConversionResponse.IsSuccessfull())
                {
                    Console.WriteLine("Conversion is ok: " + instantConversionResponse.errorMessage);
                    Console.WriteLine("Canceling subscription ...");

                    var cancelTransaction = client.NewSubscriptionCancelTransaction(response.subscriptionID);
                    cancelTransaction.SetCancelReason(1022); // Mandatory!!!

                    var cancelResponse = cancelTransaction.Send().Result;

                    if (cancelResponse.IsSuccessfull())
                    {
                        Console.WriteLine("Cancel is ok: " + cancelResponse.errorMessage);
                    }
                    else
                    {
                        Console.WriteLine("Error while cancelling subscription: " + cancelResponse.errorMessage);
                    }

                }
                else
                {
                    Console.WriteLine("Error while converting subscription: " + instantConversionResponse.errorMessage);
                }
            }
        }

    }
}
