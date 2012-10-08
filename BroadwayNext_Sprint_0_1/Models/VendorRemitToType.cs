using System;
using System.Collections.Generic;

namespace BroadwayNext_Sprint_0_1.Models
{
    public class VendorRemitToType
    {
        public System.Guid VendorRemiToTypeID { get; set; }
        public string RemitToTypes { get; set; }
        public string Inputby { get; set; }
        public Nullable<System.DateTime> Inputdate { get; set; }
        public string LastModifiedby { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    }
}
