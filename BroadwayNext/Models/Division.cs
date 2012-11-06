using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public class Division
    {
        public Division()
        {
            this.VendorTerminations = new List<VendorTermination>();
        }

        public System.Guid DivisionID { get; set; }
        public string Code { get; set; }
        public string Prefix { get; set; }
        public string GLNum { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string ComplaintEmail { get; set; }
        public string VendorInstructions { get; set; }
        public string AutofaxNotice { get; set; }
        public Nullable<System.DateTime> Inputdate { get; set; }
        public string InputBy { get; set; }
        [ScriptIgnore]
        public virtual ICollection<VendorTermination> VendorTerminations { get; set; }
    }
}
