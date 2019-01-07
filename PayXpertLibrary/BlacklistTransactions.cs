using PayXpertLibrary.Requests;
using PayXpertLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    public class BlacklistUserTransaction : TransactionBase
    {
        public BlacklistUserTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            this.requestObject = new RequestBlacklistUser();
        }

        public void DoBlacklistCardNumber()
        {
            ((RequestBlacklistUser)this.requestObject).cardNumberBlackList = "1";
        }

        public void DoBlacklistShopperEmail()
        {
            ((RequestBlacklistUser)this.requestObject).shopperEmailBlackList = "1";
        }

        public void DoBlacklistCustomerIP()
        {
            ((RequestBlacklistUser)this.requestObject).customerIPBlackList = "1";
        }

        public BaseResponseObject Send()
        {
            return SendRequestToServer<BaseResponseObject>();
        }
    }
}
