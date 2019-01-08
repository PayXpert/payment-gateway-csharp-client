using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Responses
{
    public class Response3DSCheckObject : BaseTransactionResponseObject
    {
        public string ACSUrl { get; set; }
        public string PaReq { get; set; }
    }
}
