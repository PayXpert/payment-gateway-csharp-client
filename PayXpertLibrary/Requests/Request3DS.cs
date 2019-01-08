using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Requests
{
    class Request3DSCheck : BaseRequestObject
    {
        // Transaction information

        public int amount { get; set; }
        public String currency { get; set; }
        public String orderID { get; set; }
        public String customerIP { get; set; }

        // Credit card information

        public String cardNumber { get; set; }
        public String cardSecurityCode { get; set; }
        public String cardHolderEmail { get; set; }
        public String cardExpireMonth { get; set; }
        public String cardExpireYear { get; set; }

    }

    class Request3DSParse : BaseRequestObject
    {
        public String transactionID { get; set; }
        public String PaRes { get; set; }
    }
}
