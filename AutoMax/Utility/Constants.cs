using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Utility
{
    public class Constants
    {
        public const string DATE_FORMAT = "dd MMM yyyy";

        public const string CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO = "One or more Vehicle(s) are using this information. This record can not be deleted.";
        public const string CAN_NOT_DELETE_AS_USED_IN_MODEL_INFO = "One or more {0}(s) are using this information. This record can not be deleted.";
        public const string SUCCESSFULLY_DELETED = "Record has been successfully deleted.";

        public class INVENTORYSORTINGCOLUMNS
        {
            public const string VIN = "VIN";
            public const string PlateNumber = "PlateNumber";
            public const string InventoryStatus = "InventoryStatus";
            public const string Maker = "Maker";
            public const string AutoModelName = "AutoModelName";
            public const string SubModelName = "SubModelName";
            public const string VehicleTitle = "VehicleTitle";
            public const string Odometer = "Odometer";
            public const string VehiclePrice = "VehiclePrice";
            public const string CreatedDate = "CreatedDate";

        }

        public class INVENTORYSTATUS
        {
            public const string PENDING = "PENDING";
            public const string SOLD = "SOLD";
            public const string INVENTORY = "INVENTORY";
            public const string WHOLESALE = "WHOLESALE";
            public const string TAQEEMDONE = "TAQEEM DONE";
        }
    }
}