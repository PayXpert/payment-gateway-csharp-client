using PayXpertLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDKTest
{
    partial class Program
    {
        private static int amount3ds = 10000; // 100 EUR
        private static String orderId3ds = "300";

        private static void Test3DS_Check()
        {
            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);

            Console.WriteLine("3DS: check: performing request...");

            var check3ds = client.New3DSCheckTransaction();
            check3ds.SetTransactionInformation(amount3ds, "EUR", orderId3ds, customerIP);
            check3ds.SetCardInformation("4111111111111111", "000", "hello@dolly.com", "10", "2024");

            var Check3DSResponse = check3ds.Send().Result;

            if (Check3DSResponse.IsSuccessfull())
            {
                Console.WriteLine("3DS: check: data received");
                Console.WriteLine("To open page you need to perform following post request:\n");
                Console.WriteLine("curl -X POST \\\nhttps://api.payxpert.com/mpi/pareq/45956209 \\\n  -H 'content-type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW' \\");
                Console.WriteLine("  -F 'PaReq=" + Check3DSResponse.PaReq + "' \\");                Console.WriteLine("  -F TermUrl=https://www.your-server.com \\\n  -F MD=" + orderId3ds + "\n");
                Console.WriteLine("You can copy CURL command line code, in Postman call File -> Import -> Paste RAW text and paste it there\n");
                Console.WriteLine("Please make this request, copy PaRes and paste it in file 3DS_PaRes.cs, also paste in this file transaction ID: " + Check3DSResponse.transactionID + ", and restart this project from Visual Studio");
            } else
            {
                Console.WriteLine("3DS: check: failure. Please check network connection");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void Test3DS_Parse()
        {
            String PaRes = _3DS_PaRes.PaRes;

            if (PaRes.Length == 0)
            {
                Console.WriteLine("PaRes is empty. Please run test #10 first and follow instructions");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Performing 3DS verification...");

            var client = new GatewayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);

            var parse3ds = client.New3DSParseTransaction(_3DS_PaRes.TransactionId, PaRes);
            var parse3dsResult = parse3ds.Send().Result;

            if (parse3dsResult.IsSuccessfull())
            {
                Console.WriteLine("3DS: success. Performing SALE operation");

                var transaction = client.NewSaleTransaction();

                transaction.SetTransactionInformation(amount3ds, "EUR", orderId3ds, customerIP);
                transaction.SetCardInformation("4111111111111111", "000", "CSHARP SDK", "10", "2024");
                transaction.SetShopperInformation("CSHARP SDK", "MICROSOFT HELL", "666", "REDMOND", "WA", "US", "12445", "x@x.rr");
                transaction.Set3DSInformation(PaRes, parse3dsResult);

                var response = transaction.Send().Result;

                if (response.IsSuccessfull())
                {
                    Console.WriteLine("Sale operation ok. Transaction ID: " + response.transactionID);
                } else
                {
                    Console.WriteLine("Error performing sale: " + response.errorMessage);
                }
            }
            else
            {
                Console.WriteLine("3DS parse: failure");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
