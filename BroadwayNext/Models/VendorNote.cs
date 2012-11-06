using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public class VendorNote
    {
        public System.Guid VendorNotesID { get; set; }
        public System.Guid VendorID { get; set; }
        public string NoteType { get; set; }
        public string Notes { get; set; }
        public string InputStatus { get; set; }
        public Nullable<bool> MakePublic { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        [ScriptIgnore]
        public virtual Vendor Vendor { get; set; }
    }
}
