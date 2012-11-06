using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public class VendorTermination
    {
        public System.Guid VendorTerminationID { get; set; }
        public System.Guid VendorID { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<System.DateTime> TerminationEffDate { get; set; }
        public string TerminatedBy { get; set; }
        public Nullable<System.Guid> TerminationReason { get; set; }
        public string Rehire { get; set; }
        public Nullable<System.Guid> Division { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public virtual Division Division1 { get; set; }
        public virtual TerminationReason TerminationReason1 { get; set; }
        [ScriptIgnore]
        public virtual Vendor Vendor { get; set; }
    }
}
