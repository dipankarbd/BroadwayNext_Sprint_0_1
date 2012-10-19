using System;
using System.Collections.Generic;

namespace BroadwayNext_Sprint_0_1.Models
{
    public class State
    {
        public System.Guid StateID { get; set; }
        public string State1 { get; set; }
        public string Name { get; set; }
        public Nullable<bool> ModifyTax { get; set; }
    }
}
