using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BroadwayNextWeb.Models
{
    public class VendorInsurance
    {
        public System.Guid VendorInsuranceID { get; set; }
        public System.Guid VendorID { get; set; }
        public System.Guid InsuranceType { get; set; }
        public string InsuranceName { get; set; }
        public string  Policynum { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<bool> AdditionalInsured { get; set; }
        public Nullable<bool> Not_onFile { get; set; }
        public Nullable<bool> InsuranceNotRequired { get; set; }
        public string NotRequiredReason { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public virtual VendorInsuranceType VendorInsuranceType { get; set; }
        [ScriptIgnore]
        public virtual Vendor Vendor { get; set; }
    }
}
