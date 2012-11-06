using System;
using System.Collections.Generic;

namespace BroadwayNextWeb.Models
{
    public class Vendors_Audit
    {
        public System.Guid VendorAuditID { get; set; }
        public int Vendnum { get; set; }
        public string Fieldname { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Username { get; set; }
        public string InputBy { get; set; }
        public string InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifieddate { get; set; }
    }
}
