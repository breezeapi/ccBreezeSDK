using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Contract
{
    public enum StatusType
    {
        PRN,
        SalesID,
        ShipReference,
        TransfersID,
        invoicenum,
        ordernum,
        QID
    }

    public enum AuditCodes
    {
        ADT_START_REPLICATE = 1,
        ADT_END_REPLICATE = 2,
        ADT_CHANGE_CARD = 3,
        ADT_CHANGE_ADDR = 4,
        ADT_NEW_CARD = 5,
        ADT_NEW_ADDR = 6,
        ADT_UNKNOWN = 99,
        ADT_STATUS = 100,
        ADT_ERROR = 101,
        ADT_WARNING = 102,
        ADT_SECURITY = 103
    }

}
