using PayXpertLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDKTest
{
    partial class Program
    {

        private static void BlacklistValueTest()
        {
            Console.WriteLine("Performing blacklisting of customer IP: " + customerIP);

            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var transaction = client.NewBlacklistValueTransaction();
            transaction.SetValue(BlacklistValueType.CUSTOMER_IP, customerIP);

            var blacklistResponse = transaction.Send().Result;

            if (blacklistResponse.IsSuccessfull())
            {
                Console.WriteLine("Blacklist is ok: " + blacklistResponse.errorMessage);
            }
            else
            {
                Console.WriteLine("Error blacklisting: " + blacklistResponse.errorMessage);
            }
        }

        private static void TestSaleAndBlacklist()
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
                Console.WriteLine("Performing blacklisting of card number ...");

                var blacklistTransaction = client.NewBlacklistUserTransaction(response.transactionID);

                blacklistTransaction.DoBlacklistCardNumber();

                var blacklistResponse = blacklistTransaction.Send().Result;

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
