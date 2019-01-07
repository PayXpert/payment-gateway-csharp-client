using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    public enum TransactionTypes
    {
        AUTHORIZE, CAPTURE, SALE, REFUND, REBILL, CANCEL,
        CREDIT,
        _3DSCHECK, _3DSPARSE,
        TODITO_SALE,
        BLACKLIST_TRANSACTION, BLACKLIST_VALUE,
        CANCEL_SUBSCRIPTION, STATUS_SUBSCRIPTION, EXPORT_SUBSCRIPTION, EXPORT_SUBSCRIPTION_OFFER,
        QUERY_TRANSACTION_STATUS,
        EXPORT_TRANSACTION_LIST,
        INSTANT_CONVERSION
    }
    
}
