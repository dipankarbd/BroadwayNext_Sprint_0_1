using System;
using System.Collections.Generic;

namespace BroadwayNextWeb.Models
{
    public class VendorCategory
    {
        public System.Guid VendorCategoryID { get; set; }
        public System.Guid VendorID { get; set; }
        public string VendorType { get; set; }
        public Nullable<bool> MasterType { get; set; }
        public Nullable<System.DateTime> Inputdate { get; set; }
        public string inputby { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
