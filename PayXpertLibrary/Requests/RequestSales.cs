using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Requests
{
    public abstract class BaseRequestObject
    {

    }

    public class RequestSale : BaseRequestObject
    {
        // Transaction information

        public int amount { get; set; }
        public String currency { get; set; }
        public String orderID { get; set; }
        public String customerIP { get; set; }

        // Credit card information

        public String cardNumber { get; set; }
        public String cardSecurityCode { get; set; }
        public String cardHolderName { get; set; }
        public String cardExpireMonth { get; set; }
        public String cardExpireYear { get; set; }

        // "Shopper" information

        public String shopperName { get; set; }
        public String shopperAddress { get; set; }
        public String shopperZipcode { get; set; }
        public String shopperCity { get; set; }
        public String shopperState { get; set; }
        public String shopperCountryCode { get; set; }
        public String shopperPhone { get; set; }
        public String shopperEmail { get; set; }

        // Order information

        public String orderAmount { get; set; }
        public String productID { get; set; }
        public String comment { get; set; }
        public String orderDescription { get; set; }

        // Order shipping information

        public String shipToName { get; set; }
        public String shipToAddress { get; set; }
        public String shipToZipcode { get; set; }
        public String shipToCity { get; set; }
        public String shipToState { get; set; }
        public String shipToCountryCode { get; set; }
        public String shipToPhone { get; set; }

        // Additional information

        public int? affiliateID { get; set; }
        public String campaignName { get; set; }

        // Optional AVS fields

        public String AVSPolicy { get; set; }
        public String FSPolicy { get; set; }

        // Optional 3D secure fields

        public String PaRes { get; set; }
        public String ECI { get; set; }
        public String XID { get; set; }
        public String CAVV { get; set; }
        public String CAVVAlgorithm { get; set; }

        // Optional automated subscription fields

        public int? offerID { get; set; }
        public String subscriptionType { get; set; }
        public int? rebillAmount { get; set; }
        public String rebillPeriod { get; set; }
        public int? rebillMaxIteration { get; set; }
        public String trialPeriod { get; set; }

        // Optional fraud fields

        public String threatmetrixSession { get; set; }
    }

    class RequestRefund : BaseRequestObject
    {
        // Transaction information

        public int amount { get; set; }
        public bool? cancelSubscription { get; set; }
        public string transactionID { get; set; }

    }

    class RequestCaptureRebill : BaseRequestObject
    {
        // Transaction information

        public int amount { get; set; }
        public string transactionID { get; set; }
    }

}
