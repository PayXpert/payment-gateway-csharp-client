using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Requests
{
    class RequestBlacklistUser : BaseRequestObject
    {
        public String cardNumberBlackList { get; set; }
        public String shopperEmailBlackList { get; set; }
        public String customerIPBlackList { get; set; }
    }

    class RequestBlacklistValue : BaseRequestObject
    {
        public String valueType { get; set; }
        public String value { get; set; }
    }
}
