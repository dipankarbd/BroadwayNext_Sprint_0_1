using System;
using System.Collections.Generic;

namespace BroadwayNext_Sprint_0_1.Models
{
    public class VendorTermination
    {
        public System.Guid VendorTerminationID { get; set; }
        public System.Guid VendorID { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<System.DateTime> TerminationEffDate { get; set; }
        public string TerminatedBy { get; set; }
        public string TerminationReason { get; set; }
        public string Rehire { get; set; }
        public Nullable<int> Division { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
