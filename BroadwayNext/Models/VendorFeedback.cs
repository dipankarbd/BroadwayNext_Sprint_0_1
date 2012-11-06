using System;
using System.Collections.Generic;

namespace BroadwayNextWeb.Models
{
    public class VendorFeedback
    {
        public System.Guid VendorFeedbackID { get; set; }
        public System.Guid VendorID { get; set; }
        public string FeedbackSubject { get; set; }
        public string Feedback { get; set; }
        public Nullable<int> Ratings { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
