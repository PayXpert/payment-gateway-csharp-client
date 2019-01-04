using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Responses
{
    public abstract class BaseResponseObject
    {
        public abstract bool IsSuccessfull();           
    }

    public class ResponseObject : BaseResponseObject
    {
        public string transactionID { get; set; }

        public string errorCode { get; set; }
        public string errorMessage { get; set; }

        public override bool IsSuccessfull()
        {
            return errorCode == "000";
        }
    }
}
