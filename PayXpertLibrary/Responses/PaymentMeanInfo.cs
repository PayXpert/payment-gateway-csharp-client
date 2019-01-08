using System;

namespace PayXpertLibrary.Responses
{
    public class PaymentMeanInfo
    {
        public String cardNumber { get; set; }
        public String cardExpireYear { get; set; }
        public String cardExpireMonth { get; set; }
        public String cardHolderName { get; set; }
        public String cardBrand { get; set; }
        public String cardLevel { get; set; }
        public String cardSubType { get; set; }
        public String iinCountry { get; set; }
        public String iinBankName { get; set; }

        public Boolean? is3DSecure { get; set; }
    }
}
