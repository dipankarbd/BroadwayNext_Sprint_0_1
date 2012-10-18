using System;
using System.Collections.Generic;

namespace BroadwayNext_Sprint_0_1.Models
{
    public class TerminationReason
    {
        public System.Guid TerminationReasonID { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> Inputdate { get; set; }
        public string InputBy { get; set; }
    }
}
