using PayXpertLibrary.Requests;
using PayXpertLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<BaseResponseObject> Send()
        {
            return await SendRequestToServer<BaseResponseObject>();
        }
    }

    public class BlacklistValueTransaction : TransactionBase
    {
        public BlacklistValueTransaction(TransactionTypes Type, String OriginatorId, String Password, String BaseURL) : base(Type, OriginatorId, Password, BaseURL, null)
        {
            
        }

        public void SetValue(BlacklistValueType valueType, String value)
        {
            String valueTypeStr = null;

            if (valueType == BlacklistValueType.CREDIT_CARD_NUMBER)
            {
                valueTypeStr = "creditCardNumber";                   
            }
            else if (valueType == BlacklistValueType.TODITO_CARD_NUMBER)
            {
                valueTypeStr = "toditoCardNumber";
            }
            else if (valueType == BlacklistValueType.ACCOUNT_NUMBER)
            {
                valueTypeStr = "accountNumber";
            }
            else if (valueType == BlacklistValueType.SHOPPER_EMAIL)
            {
                valueTypeStr = "shopperEmail";
            }
            else if (valueType == BlacklistValueType.CUSTOMER_IP)
            {
                valueTypeStr = "customerIP";
            }

            var requestObject = new RequestBlacklistValue();
            requestObject.valueType = valueTypeStr;
            requestObject.value = value;

            this.requestObject = requestObject;
        }

        public async Task<BaseResponseObject> Send()
        {
            return await SendRequestToServer<BaseResponseObject>();
        }
    }
}
