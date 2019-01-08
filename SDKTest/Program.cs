using PayXpertLibrary;
using System;

namespace SDKTest
{
    partial class Program
    {
        private static String customerIP = "8.8.9.9";

        private static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("=============================================================");
                Console.WriteLine("|                 PayXpert C# SDK demo                      |");
                Console.WriteLine("|                (c) 2019, PayXpert Ltd                     |");
                Console.WriteLine("|               https://www.payxpert.com                    |");
                Console.WriteLine("=============================================================");
                Console.WriteLine("\n");
                Console.WriteLine("Please choose test to perform:\n");

                Console.WriteLine("1: Sale, refund and rebill");
                Console.WriteLine("2: Export transactions: last month");
                Console.WriteLine("3: Authorize + capture");
                Console.WriteLine("4: Authorize + cancel");
                Console.WriteLine("5: Sale + credit funds transfer");
                Console.WriteLine("6: Sale + blacklist card number");
                Console.WriteLine("7: Blacklist customer IP " + customerIP);
                Console.WriteLine("8: Subscription: create, instant conversion, cancel");
                Console.WriteLine("9: Subscription: export list");

                Console.WriteLine("\nType 0 to exit\n");

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
                else if (key.KeyChar == '5')
                {
                    TestSaleAndCFT();
                }
                else if (key.KeyChar == '6')
                {
                    TestSaleAndBlacklist();
                }
                else if (key.KeyChar == '7')
                {
                    BlacklistValueTest();
                }
                else if (key.KeyChar == '8')
                {
                    TestSubscriptionInstantConversion();
                }
                else if (key.KeyChar == '9')
                {
                    TestExportSubscriptions();
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
