using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public partial class VendorContact
    {
        public System.Guid VendorContactID { get; set; }
        public System.Guid VendorID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
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
        public string Mobile { get; set; }
        public string Title { get; set; }
        public string ContactType { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> ActiveType { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        [ScriptIgnore]
        public virtual Vendor Vendor { get; set; }
    }
}
