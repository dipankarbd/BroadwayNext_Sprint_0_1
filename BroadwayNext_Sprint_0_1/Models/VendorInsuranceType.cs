using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNext_Sprint_0_1.Models
{
    public class VendorInsuranceType
    {
        public VendorInsuranceType()
        {
            this.VendorInsurances = new List<VendorInsurance>();
        }

        public System.Guid InsuranceTypeID { get; set; }
        public string InsuranceType { get; set; }
        [ScriptIgnore]
        public virtual ICollection<VendorInsurance> VendorInsurances { get; set; }
    }
}
