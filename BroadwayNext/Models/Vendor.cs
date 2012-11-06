using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BroadwayNextWeb.Models
{
    public class Vendor
    {
        public Vendor()
        {
            this.VendorCategories = new List<VendorCategory>();
            this.VendorContacts = new List<VendorContact>();
            this.VendorFeedbacks = new List<VendorFeedback>();
            this.VendorInsurances = new List<VendorInsurance>();
            this.VendorNotes = new List<VendorNote>();
            this.VendorRemitToes = new List<VendorRemitTo>();
            this.VendorShipToes = new List<VendorShipTo>();
            this.VendorTerminations = new List<VendorTermination>();
        }

        public System.Guid VendorID { get; set; }
        public int Vendnum { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string DBA { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Phone { get; set; }
        public Nullable<int> PhoneExt { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Emergency { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string AutoEmail { get; set; }
        public string Comment { get; set; }
        public Nullable<System.Guid> VendorType { get; set; }
        public string GLnum { get; set; }
        public string TaxID { get; set; }
        public Nullable<int> NetDays { get; set; }
        public Nullable<bool> CheckTax1099 { get; set; }
        public Nullable<bool> PVA { get; set; }
        public Nullable<bool> SignedContract { get; set; }
        public Nullable<bool> CreditCardHolder { get; set; }
        public Nullable<bool> W9 { get; set; }
        public Nullable<System.Guid> PaymentTerms { get; set; }
        public Nullable<System.Guid> CashDiscount { get; set; }
        public string PricingYear { get; set; }
        public Nullable<int> Overallrating { get; set; }
        public string WebAccessUser { get; set; }
        public string WebAccessPwd { get; set; }
        public string InputBy { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.Guid> GradeID { get; set; }
        public virtual ICollection<VendorCategory> VendorCategories { get; set; }
        public virtual ICollection<VendorContact> VendorContacts { get; set; }
        public virtual ICollection<VendorFeedback> VendorFeedbacks { get; set; }
        public virtual ICollection<VendorInsurance> VendorInsurances { get; set; }
        public virtual ICollection<VendorNote> VendorNotes { get; set; }
        public virtual ICollection<VendorRemitTo> VendorRemitToes { get; set; }
        public virtual ICollection<VendorShipTo> VendorShipToes { get; set; }
        public virtual ICollection<VendorTermination> VendorTerminations { get; set; }
    }
}
