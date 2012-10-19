using System;
using System.Collections.Generic;

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
        public virtual ICollection<VendorInsurance> VendorInsurances { get; set; }
    }
}
