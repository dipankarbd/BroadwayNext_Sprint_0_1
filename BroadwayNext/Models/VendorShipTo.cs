using System;
using System.Collections.Generic;

namespace BroadwayNextWeb.Models
{
    public class VendorShipTo
    {
        public System.Guid VendorShipToID { get; set; }
        public System.Guid VendorID { get; set; }
        public string Recipient { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
