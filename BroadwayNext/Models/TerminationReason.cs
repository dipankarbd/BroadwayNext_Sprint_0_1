using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public class TerminationReason
    {
        public TerminationReason()
        {
            this.VendorTerminations = new List<VendorTermination>();
        }

        public System.Guid TerminationReasonID { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> Inputdate { get; set; }
        public string InputBy { get; set; }
        [ScriptIgnore]
        public virtual ICollection<VendorTermination> VendorTerminations { get; set; }
    }
}
