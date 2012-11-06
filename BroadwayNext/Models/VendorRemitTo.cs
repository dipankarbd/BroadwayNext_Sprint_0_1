using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public partial class VendorRemitTo
    {
        public System.Guid VendorRemitToID { get; set; }
        public System.Guid VendorID { get; set; }
        public string Company { get; set; }
        public string RemitType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Phone { get; set; }
        public Nullable<int> PhoneExt { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        [ScriptIgnore]
        public virtual Vendor Vendor { get; set; }
    }
}
