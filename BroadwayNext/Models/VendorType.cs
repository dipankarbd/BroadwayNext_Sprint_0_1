using System;
using System.Collections.Generic;

namespace BroadwayNextWeb.Models
{
    public class VendorType
    {
        public System.Guid VendorTypeID { get; set; }
        public string VendorType1 { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    }
}
