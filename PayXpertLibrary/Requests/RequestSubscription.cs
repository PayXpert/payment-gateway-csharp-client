using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary.Requests
{
    class RequestCancelSubscription : BaseRequestObject
    {
        public int cancelReason { get; set; }
    }
}
