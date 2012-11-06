using System;
using System.Collections.Generic;

namespace BroadwayNextWeb.Models
{
    public class StateTaxable
    {
        public System.Guid StateTaxableID { get; set; }
        public System.Guid StateID { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> Inputdate { get; set; }
        public string Inputby { get; set; }
    }
}
