using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BroadwayNext_Sprint_0_1.Models.DummyModel
{
    public class TheVendor
    {
        //subset of Actual Vendor
        public int VendorNum { get; set; }
        [Required, StringLength(20)]
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string DBA { get; set; }
        public string VendorType { get; set; }
        public string Terms { get; set; }
        public string Emergency { get; set; }
        public bool Active { get; set; }
        public bool? W9 { get; set; }
        public DateTime? InputDate { get; set; }
        public string InputBy { get; set; }
    }
}